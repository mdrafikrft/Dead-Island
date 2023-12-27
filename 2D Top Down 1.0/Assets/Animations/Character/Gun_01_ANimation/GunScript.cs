using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField] Animator animator;

    public void isDead(bool dead)
    {
        animator.SetBool("Dead", dead);
    }
}
