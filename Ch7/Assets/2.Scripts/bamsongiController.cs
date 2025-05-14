using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bamsongiController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

       // Shoot(new Vector3(0, 200, 3000));
    }

    // Update is called once per frame
    public void Shoot(Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce(dir);
    }
    private void OncOllisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<ParticleSystem>().Play();
    }
}
