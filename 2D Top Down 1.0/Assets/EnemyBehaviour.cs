using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform player;

    Rigidbody2D enemyRb;
    bool facingRight = false;

    private void Awake()
    {
        enemyRb = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        Vector3 scale = transform.localScale;

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

    private void Flip()
    {
        /*Vector2 currentPosition = gameObject.transform.position;
        currentPosition.x *= -1;

        gameObject.transform.position = currentPosition;
        facingRight = !facingRight;*/
        
    }
}
