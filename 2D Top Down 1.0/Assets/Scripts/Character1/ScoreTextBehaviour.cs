using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTextBehaviour : MonoBehaviour
{
    private float scoreLife = 0.5f;

    private void Start()
    {
        Destroy(gameObject, scoreLife);
    }
}
