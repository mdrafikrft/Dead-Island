using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float life;
    

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, life);

                
    }

    
    private void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Instantiate(deathEffect, collision.gameObject.transform.position, Quaternion.identity);
        if (collision.gameObject.CompareTag("EnemyTag"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        
    }
}
