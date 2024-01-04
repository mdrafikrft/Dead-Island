using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart_Behaviour : MonoBehaviour
{
    Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void Start()
    {
        rb.AddForce(transform.up * 2.0f);
        
    }
}
