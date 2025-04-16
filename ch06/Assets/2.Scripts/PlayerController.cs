using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    float jumpForce = 370f;
    float walkForce = 30f;
    float maxWalkSpeed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rigid2D.AddForce(transform.up * jumpForce);
            //rigid2D.AddForce(new Vector2(0,1) * jumpForce));
        }

        int key = 0;
        if(Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;
        
        float speedx = Mathf.Abs(rigid2D.velocity.x);

        if (speedx < maxWalkSpeed)
        {
            rigid2D.AddForce(transform.right * key * walkForce);
        }

        if(key !=0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }
    }
}
