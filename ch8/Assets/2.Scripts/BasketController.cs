using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    public AudioClip appleSE;
    public AudioClip bombSE;
    AudioSource aud;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                float x = Mathf.Round(hit.point.x);
                float z = Mathf.Round(hit.point.z);
                transform.position = new Vector3(x, transform.position.y, z);

            }
        }
    }

    //private void onCollisionEnter(Collision collision)
    //{
    //   Debug.Log("Collision detected with: " + collision.gameObject.name);
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Apple")
        {
            aud.PlayOneShot(appleSE);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Bomb")
        {
            aud.PlayOneShot(bombSE);
            Destroy(other.gameObject);
        }
    }
}
