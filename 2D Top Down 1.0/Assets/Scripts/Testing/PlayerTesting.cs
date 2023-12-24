using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTesting : MonoBehaviour
{
    Rigidbody2D rb;
    InputControllerPlyer inputManager;

    [SerializeField] float speed = 10.0f;
    [SerializeField] Transform bulletSpot;
    [SerializeField] GameObject bulletPrefab;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputManager = new InputControllerPlyer();

        inputManager.Player.Movement.performed += Movement_performed;
        inputManager.Player.Fire.performed += Fire_performed;

    }

    public void Fire_performed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Instantiate(bulletPrefab, bulletSpot.position, bulletSpot.rotation);

        }
    }

    public void Movement_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        Vector2 move = context.ReadValue<Vector2>();
        rb.velocity = new Vector2(move.x, move.y) * speed;

        if(move != Vector2.zero)
        {
            transform.up = move;
        }
    }
}
