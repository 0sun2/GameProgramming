using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public int maxHealth = 100;
    public GameObject bulletPrefab;
    public Transform firePoint;

    private int currentHealth;
    private Rigidbody2D rb;
    private bool isFacingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        float moveInputX = Input.GetAxisRaw("Horizontal");
        float moveInputY = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(moveInputX * moveSpeed, moveInputY * moveSpeed);

        if (moveInputX > 0 && !isFacingRight) Flip();
        else if (moveInputX < 0 && isFacingRight) Flip();

        if (Input.GetKeyDown(KeyCode.LeftControl))
            Shoot();
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Vector2 dir = isFacingRight ? Vector2.right : Vector2.left;
        bullet.GetComponent<Bullet>().SetDirection(dir);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
            Destroy(gameObject);
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
} 