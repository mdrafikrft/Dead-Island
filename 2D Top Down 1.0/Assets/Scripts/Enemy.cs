using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Vector3 directionToPlayer;
    Rigidbody2D enemyRb;
    int damage;

    private Transform player;
    public Transform EnemyBulleteSpawnPlace;
    public float bulletSpawnRate;
    public int health;
    
    
    private void Awake()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        damage = FindObjectOfType<BulletBehaviour>().damage;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, GetDirection(), Color.white);
    }

    public Vector3 GetDirection()
    {
        Vector3 directionToPlayer = new Vector3(0f, 0f, 0f);
        if (gameObject != null)
        {
            directionToPlayer = player.position - transform.position;
            directionToPlayer.Normalize();            
        }
        return directionToPlayer;

    }

    private void RotateTowardsPlayer()
    {
        Vector3 Direction = GetDirection();
        float angle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg - 90.0f;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, 0.5f);
    }
    private void FixedUpdate()
    {
        RotateTowardsPlayer();
        Vector3 direction = GetDirection();
        enemyRb.velocity = new Vector3(direction.x, direction.y, 0) * 0.5f;
    }



    
}
