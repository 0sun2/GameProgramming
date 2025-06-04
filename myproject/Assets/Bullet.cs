using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    public float lifetime = 2f;
    public int damage = 1;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    public void SetDirection(Vector2 dir)
    {
        GetComponent<Rigidbody2D>().velocity = dir * speed;
        if (dir.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyController>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
} 