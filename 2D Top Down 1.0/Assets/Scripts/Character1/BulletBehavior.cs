using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float life;
    //[SerializeField] ParticleSystem destroyParticle;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, life);

        //destroyParticle = FindObjectOfType<ParticleSystem>();
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
            /*Instantiate(destroyParticle, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);*/
            
            Destroy(gameObject);
        }
        
    }
}
