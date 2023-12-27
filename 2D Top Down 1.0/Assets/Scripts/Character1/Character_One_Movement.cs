using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Character_One_Movement : MonoBehaviour
{
    [SerializeField] float speedOfPlayer;
    [SerializeField] Transform GunFireLightSpot;
    [SerializeField] GameObject GunfireLight;
    [SerializeField] GameObject BulletPrefab;
    [SerializeField] Animator animator;
 
    CharacterInput characterInput;
    Rigidbody2D characterRb;
    bool facingRight = true;

    GunScript gunScript;

    private void Awake()
    {
        characterInput = new CharacterInput();
        characterRb = GetComponent<Rigidbody2D>();
        gunScript = FindObjectOfType<GunScript>();

        characterInput.Character_First.Movement.performed += Movement_performed;
        characterInput.Character_First.Fire.performed += Fire_performed;

        //animator.SetFloat("Idle", 0);
    }

    public void Fire_performed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Instantiate(GunfireLight, GunFireLightSpot.position, GunfireLight.transform.rotation);
            Instantiate(BulletPrefab, GunFireLightSpot.position, GunFireLightSpot.transform.rotation);
        }
    }

    public void Movement_performed(InputAction.CallbackContext context)
    {
       

        if (context.performed)
        {
            Vector2 InputValue = context.ReadValue<Vector2>();
            characterRb.velocity = new Vector3(InputValue.x, InputValue.y, 0) * speedOfPlayer;

            Debug.Log(InputValue.x);

            if (InputValue.x > 0 && !facingRight)
            {
                Flip();
            }
            else if (InputValue.x < 0 && facingRight)
            {
                Flip();
            }

            Debug.Log(InputValue.x);
        }

        else if (context.canceled)
        {
             
            characterRb.velocity = new Vector3(0f, 0f, 0f);
        }
        
    }

    private void Flip()
    {
        Vector2 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            animator.SetBool("Dead", true);
            gunScript.isDead(true);
            Destroy(gameObject, 2);
        }
    }

    
}
