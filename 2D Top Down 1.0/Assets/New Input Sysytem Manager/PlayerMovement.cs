using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    InputManager inputManager;
    Rigidbody2D rb;

    public GameObject bulletPrefab;

    [SerializeField] float speed = 3.0f;
    [SerializeField] GameObject bulletSpawnSpot;

    private void Awake()
    {
        inputManager = new InputManager();
        rb = GetComponent<Rigidbody2D>();

        //inputManager.Player.Movement.Enable();

        inputManager.Player.Movement.performed += Movement_performed;
        inputManager.Player.Fire.performed += Fire_performed;
        
    }

    public void Fire_performed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Instantiate(bulletPrefab, bulletSpawnSpot.transform.position, Quaternion.identity);
        }
    }

    public void Movement_performed(InputAction.CallbackContext context)
    {
        Vector2 inputValue = context.ReadValue<Vector2>();

        if (context.performed)
        {
            Debug.Log(context);
            
            rb.velocity = new Vector3(inputValue.x, inputValue.y, 0) * speed;
          
        }
        else if (context.canceled)
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
        
    }
}
