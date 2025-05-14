using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTF : MonoBehaviour
{
    public float moveSpeed = 15f;
    public float rotationSpeed = 5f;

    
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        
        float moveX = xInput * moveSpeed * Time.deltaTime;
        float moveZ = zInput * moveSpeed * Time.deltaTime;
        transform.Translate(moveX, 0, moveZ);
    }
}
