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

    float playerX;
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
            playerX = GameObject.FindGameObjectWithTag("Player").
                     GetComponent<Character_One_Movement>().playerXPosition();

            player.position = new Vector3(playerX, player.position.y, player.position.z);
            float gap = transform.position.x - player.position.x;
            if(gap > 45.0f || gap < -45.0f)
            {
                /*Debug.Log("Player : " + player.position.x);
                Debug.Log("Bullet : " + transform.position.x);*/
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
