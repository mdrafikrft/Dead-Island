using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	public float speed;

	public GameObject effect;
	public GameObject effectTwo;

	public GameObject sound;

	private void Start()
	{
		Instantiate(sound);
	}
	private void Update()
	{
		transform.Translate(Vector2.right * speed * Time.deltaTime);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Enemy")){ 
			other.GetComponent<Enemy>().health--;
			Instantiate(effect, transform.position, Quaternion.identity);
			Instantiate(effectTwo, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}
}
