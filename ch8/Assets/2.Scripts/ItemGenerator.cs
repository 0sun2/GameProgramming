using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject applePrefab;
    public GameObject bombPrefab;

    float span = 1f;
    float delta = 0f;
    int ratio = 2;
    float speed = -0.03f;

    public void SetParameters(float span, int ratio, float speed)
    {
        this.span = span;
        this.ratio = ratio;
        this.speed = speed;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime;
        if (delta > span)
        {
            Instantiate(applePrefab, transform.position, transform.rotation);
            delta = 0;
            GameObject item;
            int dice = Random.Range(1, 11);
            if (dice <= ratio)
            {
                item = Instantiate(applePrefab);
            }
            else
            {
                item = Instantiate(bombPrefab);
            }
            float x = Random.Range(-1, 2);
            float z = Random.Range(-1, 2);
            item.transform.position = new Vector3(x, 4, z);
            item.GetComponent<ItemController>().dropSpeed = this.speed;
        }
    }
}
