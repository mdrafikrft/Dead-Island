using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFireLight : MonoBehaviour
{
    [SerializeField] float lifeSpan;

    private void Awake()
    {
        Destroy(gameObject, lifeSpan);
    }
}
