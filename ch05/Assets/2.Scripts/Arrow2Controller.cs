using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow2Controller : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}