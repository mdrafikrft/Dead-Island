using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Vector3 directionToPlayer;
    Rigidbody2D enemyRb;

    private Transform player;
    

    private void Awake()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        //Debug.DrawLine(transform.position, directionToPlayer, Color.green);
    }

    private void Update()
    {
        

    }
    private void FixedUpdate()
    {
        Vector3 directionToPlayer = player.position - transform.position;
        directionToPlayer.Normalize();

        Debug.DrawRay(transform.position, directionToPlayer, Color.white);

        enemyRb.velocity = new Vector3(directionToPlayer.x, directionToPlayer.y, 0) * 3.0f;
    }
}
