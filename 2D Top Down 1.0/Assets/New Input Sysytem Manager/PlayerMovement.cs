using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    InputManager inputManager;
    Rigidbody2D rb;
    float r;

    public Camera cam;
    public GameObject bulletPrefab;

    [SerializeField] float speed = 3.0f;
    [SerializeField] GameObject bulletSpawnSpot;
    [SerializeField] Vector3 mousePosition;
    [SerializeField] float rotationSpeed = 720.0f;


    private void Awake()
    {
        inputManager = new InputManager();
        rb = GetComponent<Rigidbody2D>();

        //inputManager.Player.Movement.Enable();

        inputManager.Player.Movement.performed += Movement_performed;
        inputManager.Player.Fire.performed += Fire_performed;
        
    }

    private void Update()
    {

        //PlayerFacingForward();
    }

    public void Fire_performed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Instantiate(bulletPrefab, bulletSpawnSpot.transform.position, transform.localRotation);
        }
    }

    public void Movement_performed(InputAction.CallbackContext context)
    {
        Vector2 inputValue = context.ReadValue<Vector2>();

        if (context.performed)
        {
            Debug.Log(context);
            
            rb.velocity = new Vector3(inputValue.x, inputValue.y, 0) * speed;

            if(inputValue != Vector2.zero)
            {
                transform.up = inputValue;

                Vector2 direction = transform.up - transform.position;
                float angleQ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90.0f; 
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.z, angleQ, ref r, 1.0f);

                transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
            }
          
        }
        else if (context.canceled)
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
        
    }

    private void PlayerFacingForward()
    {
        /*mousePosition = cam.WorldToScreenPoint(Input.mousePosition);
        Vector3 direction = mousePosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90.0f;
        transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
       // transform.localRotation = Quaternion.Slerp(transform.localRotation, q, 10.0f);*/

        
    }
}
