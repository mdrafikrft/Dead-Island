using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform player;

    Rigidbody2D enemyRb;
    

    private void Awake()
    {
        enemyRb = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        Vector3 scale = transform.localScale;

        if(player != null)
        {
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
        }
        else
        {
            enemyRb.velocity = new Vector3(0f, 0f, 0f);
        }
    }

    
}
