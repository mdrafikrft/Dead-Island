using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart_Spawner : MonoBehaviour
{
    public GameObject[] hearts;
    private int heartIndex;
    
    public Transform player;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int Index = Random.Range(0, hearts.Length);
            Instantiate(hearts[Index], player.position, Quaternion.identity);
        }
        
    }

}
