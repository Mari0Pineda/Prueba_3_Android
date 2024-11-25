using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Script : MonoBehaviour
{
    //Referencias privadas
    Rigidbody playerRb;
    PlayerInput playerInput;
    Vector2 moveInput;

    [Header("Player Stats")]
    [SerializeField] float speed;
    public float jumpForce;
    [SerializeField] bool isGrounded;

    [Header("Combat Parameters")]
    public int ammo;
    public int maxAmmo;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform shootPosition;
    Vector2 move;
    Vector2 look;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerRb = GetComponent<Rigidbody>();
        ammo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        playerRb.velocity = new Vector3(moveInput.x * speed, playerRb.velocity.y, 0);
        Debug.Log(moveInput);
        Debug.Log(playerRb.velocity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    public void Move(InputAction.CallbackContext context)
    {


        //A la variable constante de Vector2 que va a definir la dirección del jugador, le pasaremos el valor del joystick
        moveInput = context.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.started && isGrounded)
        {
            isGrounded = false;
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    public void SpecialAction(InputAction.CallbackContext context)
    {
        if (context.started && ammo > 0)
        {
            Instantiate(bulletPrefab, shootPosition.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("No tienes munición!");
        }
    }
}
