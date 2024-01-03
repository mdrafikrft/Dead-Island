using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlay : MonoBehaviour
{
    public AudioSource burstSOund;

    public void PlaySound()
    {
        burstSOund.Play();
    }
}
