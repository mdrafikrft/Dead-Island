using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Enemy : MonoBehaviour
{
    private Animator anim;
	public float minAnimSpeed;
	public float maxAnimSpeed;

	public float speed;
	private Transform target;

	public int damage;
	public int health;
	public GameObject deathEffect;

	public bool isPatrol;
	public float minX;
	public float maxX;
	public float minY;
	public float maxY;
	private Vector2 patrolTarget;

	public GameObject scorePopUp;

	public GameObject chest;

	private void Start()
	{
		anim = GetComponent<Animator>();
		anim.speed = Random.Range(minAnimSpeed, maxAnimSpeed);

		target = GameObject.FindGameObjectWithTag("Player").transform;

		patrolTarget = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
	}

	private void Update()
	{
		if(isPatrol){
			transform.position = Vector2.MoveTowards(transform.position, patrolTarget, speed * Time.deltaTime);

			if(Vector2.Distance(transform.position, patrolTarget) < 0.2f){ 
				patrolTarget = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
			}
		} else{
			transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
		}
		

		if(health <= 0){ 

			int randChance = Random.Range(0, 20);
			if(randChance == 1){
				Instantiate(chest, transform.position, Quaternion.identity);
			}
			

			GameObject instance = Instantiate(scorePopUp, transform.position, Quaternion.identity);
			int randScoreBonus = Random.Range(1, 6);
			target.GetComponent<Player>().score += randScoreBonus;
			instance.GetComponentInChildren<TextMeshProUGUI>().text = "+" + randScoreBonus;
			Instantiate(deathEffect, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}


	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Player")){ 

			other.GetComponent<Player>().TakeDam(damage);
		}
	}
}
