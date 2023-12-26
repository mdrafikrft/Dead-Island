using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilProjectile : MonoBehaviour
{
    public float speed;

    private Transform player;
	private Vector2 target;
	public GameObject effect;

	private void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		target = player.position;
	}

	private void Update()
	{
		transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
		if(Vector2.Distance(transform.position, target)<0.2f){ 
			Instantiate(effect, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Player")){
			other.GetComponent<Player>().TakeDam(1);
			Instantiate(effect, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}
}
