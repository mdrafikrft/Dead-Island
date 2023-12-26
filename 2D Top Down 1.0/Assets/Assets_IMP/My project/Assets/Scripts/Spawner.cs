using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float startTimeBtwSpawn;
    private float timeBtwSpawn;

    public GameObject[] enemies;
	public Transform spawnPos;

	private Player player;

	private void Start()
	{
		player = FindObjectOfType<Player>();
	}

	private void Update()
	{
		if(timeBtwSpawn <= 0 && player.isDead == false){ 
			int randEnemy = Random.Range(0, enemies.Length);
			Instantiate(enemies[randEnemy], spawnPos.position, Quaternion.identity);
			timeBtwSpawn = startTimeBtwSpawn;
		} else{ 
			timeBtwSpawn -= Time.deltaTime;		
		}
	}
}
