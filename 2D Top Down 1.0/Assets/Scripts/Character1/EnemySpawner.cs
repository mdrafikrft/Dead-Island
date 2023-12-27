using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] Enemies;
    [SerializeField] float spawnRate;
    [SerializeField] bool isSpawning;

    private void Start()
    {
        StartCoroutine(EnemySpawn());
    }

    IEnumerator EnemySpawn()
    {
        while (isSpawning)
        {
            yield return new WaitForSeconds(spawnRate);
            int randIndex = Random.Range(0, Enemies.Length);
            Instantiate(Enemies[randIndex], transform.position, Quaternion.identity);
        }
    }
}
