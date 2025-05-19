using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BamsongiGenerator : MonoBehaviour
{
    public GameObject bamsongiPrefab;
    // Start is called before the first frame update

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bamsongi = Instantiate(bamsongiPrefab,transform.position, transform.rotation);

            bamsongi.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z + 1);
            //bamsongi.GetComponent<bamsongiController>().Shoot(new Vector3(0, 200, 2000));

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 worldDir = ray.direction;
            bamsongi.GetComponent<bamsongiController>().Shoot(worldDir * 2000);
        }


    }
}