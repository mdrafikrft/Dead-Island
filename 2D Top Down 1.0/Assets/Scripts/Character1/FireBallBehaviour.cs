using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallBehaviour : MonoBehaviour
{
    [SerializeField] float speed;

    Transform player;
    Vector2 targetPosition;
    Rigidbody2D rb;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        targetPosition = player.position;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if(transform.position.x == targetPosition.x && transform.position.y == targetPosition.y)
        {
            Destroy(gameObject);
        }
    }


}
