using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] float lifeOfBullet = 5.0f;
    [SerializeField] float speedOfBullet = 100.0f;

    Rigidbody2D bulletRb;

    private void Awake()
    {
        bulletRb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeOfBullet);
    }

    private void FixedUpdate()
    {
        bulletRb.velocity = new Vector3(0, speedOfBullet, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }

}
