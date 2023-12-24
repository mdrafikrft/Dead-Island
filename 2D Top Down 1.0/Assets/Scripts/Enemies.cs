using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField] private Transform player;

    Rigidbody2D enemyRb;

    private void Awake()
    {
        enemyRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector3 d = GetDirection();
        Debug.Log(d);
    }

    private void FixedUpdate()
    {
        chasePlayer();
    }

    public Vector3 GetDirection()
    {
        Vector3 direction = player.position - transform.position;
        Debug.DrawRay(transform.position, direction, Color.green);
        direction.Normalize();

        return direction;
    }

    private void chasePlayer()
    {
        Vector3 direction = GetDirection();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90.0f;
        Quaternion q = Quaternion.Euler(new Vector3(0f, 0f, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, 0.5f);

        enemyRb.velocity = new Vector3(direction.x, direction.y, 0f) * 0.5f;
        
    }
}
