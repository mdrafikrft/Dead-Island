using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] bool isSpawning;
    [SerializeField] int spawnRate = 5;

    private void Awake()
    {
        StartCoroutine(enemySpawn());
    }
    
    IEnumerator enemySpawn()
    {
        while (isSpawning)
        {
            yield return new WaitForSeconds(spawnRate);
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        }
    }
}
