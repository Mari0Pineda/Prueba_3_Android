using System.Collections;
using TreeEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement_Script : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private float speed = 5f; // Movement speed
    [SerializeField] private float mouseSensitivity = 100f; // Mouse look sensitivity
    [SerializeField] private CharacterController controller; // Reference to CharacterController

    [Header("Camera")]
    public Transform playerCamera; // Assign the Camera transform in the Inspector

    private float xRotation = 0f; // Tracks vertical rotation for clamping
    private PlayerInput playerInput;
    private InputAction moveAction; // Action for movement input
    private InputAction lookAction; // Action for mouse/joystick look input

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();

        if (playerInput != null)
        {
            moveAction = playerInput.actions["Move"]; // Map movement action
            lookAction = playerInput.actions["Look"]; // Map look action
        }
        else
        {
            Debug.LogError("PlayerInput component is missing!");
        }
    }

    private void Start()
    {
        // Lock the cursor to the center of the screen and hide it
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        HandleMovement();
        HandleMouseLook();
    }

    private void HandleMovement()
    {
        if (controller != null)
        {
            
            Vector2 inputVector = moveAction.ReadValue<Vector2>();

            // Calculate movement in world space relative to the camera
            Vector3 move = transform.right * inputVector.x + transform.forward * inputVector.y;

            // Move the player using the CharacterController
            controller.Move(move * speed * Time.deltaTime);
        }
    }

    private void HandleMouseLook()
    {
        // Get the mouse delta (or right stick on gamepad)
        Vector2 lookInput = lookAction.ReadValue<Vector2>();

        // Adjust vertical rotation (X-axis) and clamp it
        xRotation -= lookInput.y * mouseSensitivity * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Rotate the camera around its X-axis
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotate the player horizontally (Y-axis)
        float mouseX = lookInput.x * mouseSensitivity * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);
    }
}
