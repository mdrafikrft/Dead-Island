using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
	public GameObject effectOne;
	public GameObject effectTwo;

	private Player player;

	private void Start()
	{
		player = FindObjectOfType<Player>();
	}
	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Player")){ 
			player.score += 100;
			player.cam.SetTrigger("shake");
			Instantiate(effectTwo, transform.position, Quaternion.identity);
			Instantiate(effectOne, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}
}
