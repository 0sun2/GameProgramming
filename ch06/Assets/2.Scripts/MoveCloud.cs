using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCloud : MonoBehaviour
{
    public float speed = 2f; 
    public float leftBoundaryX = -10f; 
    public float rightBoundaryX = 10f; 
    public int initialDirection = 1; 

    private int direction;

    
    void Start()
    {
        
        direction = initialDirection;
    }

   
    void Update()
    {
        
        transform.Translate(Vector3.right * direction * speed * Time.deltaTime);

        
        if (transform.position.x < leftBoundaryX)
        {
            direction = 1;
        }

        
        if (transform.position.x > rightBoundaryX)
        {
            direction = -1;
        }
    }
}
