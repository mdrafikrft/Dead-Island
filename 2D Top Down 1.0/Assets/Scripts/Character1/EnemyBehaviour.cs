using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] float speed;
    
    Transform player;

    [SerializeField] Transform firingSpot;
    float timeBtwShots;
    [SerializeField] float startTimeBtwShots;

    Rigidbody2D enemyRb;
    

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyRb = GetComponent<Rigidbody2D>();
        timeBtwShots = startTimeBtwShots;

    }

    private void FixedUpdate()
    {
        Vector3 scale = transform.localScale;

        if (player != null)
        {
            //Character_One_Movement Towards The Player
            Vector3 direction = player.position - transform.position;
            enemyRb.velocity = new Vector3(direction.x, direction.y, 0f) * speed * Time.fixedDeltaTime;

            if (player.position.x > transform.position.x)
            {
                scale.x = Mathf.Abs(scale.x) * -1;
                transform.localScale = scale;
            }
            else if (player.position.x < transform.position.x)
            {
                scale.x = Mathf.Abs(scale.x);
                transform.localScale = scale;
            }

            //Firing Projectile towards player :
            /*if (timeBtwShots <= 0)
            {
                Instantiate(projectile, firingSpot.position, Quaternion.identity);
                timeBtwShots = startTimeBtwShots;
            }
            else if (timeBtwShots > 0)
            {
                timeBtwShots -= Time.deltaTime;
            }*/
        }
        else
        {
            enemyRb.velocity = new Vector3(0f, 0f, 0f);
        }

        
    }

    
}
