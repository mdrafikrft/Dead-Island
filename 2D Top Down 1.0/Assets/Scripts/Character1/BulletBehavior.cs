using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float life;
    [SerializeField] Transform player;
    [SerializeField] GameObject bulletDitroyEffectPrefab;

    
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

    private void Update()
    {
        if(player != null)
        {
            float gap = Mathf.Abs((transform.position.x - player.position.x));
            if(gap > 45.0f)
            {
                Instantiate(bulletDitroyEffectPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
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
