using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesBehaviour : MonoBehaviour
{
    float life = 1.5f;
    private void Awake()
    {
        Destroy(gameObject, life);
    }
}
