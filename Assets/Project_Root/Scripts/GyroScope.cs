using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GyroScope : MonoBehaviour
{
    //Referencias privadas
    Ray playerRay;
    RaycastHit visionHit;

    [Header("Raycasting Data")]
    [SerializeField] private Camera playerCam;
    [SerializeField] float visionRange;
    [SerializeField] LayerMask hitLayer;

    [Header("Visual Feedback")]
    [SerializeField] GameObject pickUpUIFeedback;
    [SerializeField] GameObject[] notesUI;

    [Header("Numeros")]
    [SerializeField] GameObject[] numeroUI;

    [Header("Player Stats")]
    public bool onInteract;

    // Movement variables
    [SerializeField] private float speed = 3.3f;
    [SerializeField] private CharacterController controller;
    [SerializeField] private PlayerInput playerInput;
    private InputAction moveAction;  // For joystick movement
    private Vector3 moveDirection = Vector3.zero;
    Vector3 moveInput;

    // Gyroscope variables
    private float _initialYAngle = 0f;
    private float _appliedGyroAngle = 0f;
    private float _calibrationYAngle = 0f;
    private Transform _rawGyroRotation;
    private float _smoothing = 0.1f;

    public AudioSource footstepsSound;

    private void Awake()
    {

    }

    private void Start()
    {
        // Fetch the CharacterController component attached to this GameObject
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        if (controller == null)
        {
            Debug.LogError("CharacterController component is missing from this GameObject.");
        }

        // Get Player Input component and the action for movement
        playerInput = GetComponent<PlayerInput>();
        if (playerInput != null)
        {
            moveAction = playerInput.actions["Move"];
        }
        else
        {
            Debug.LogError("PlayerInput component is missing from this GameObject.");
        }
        // Enable the gyroscope and start calibration
        StartCoroutine(StartGyro());
    }

    private IEnumerator StartGyro()
    {
        Input.gyro.enabled = true;
        Application.targetFrameRate = 60;

        _initialYAngle = transform.eulerAngles.y;
        _rawGyroRotation = new GameObject("GyroRaw").transform;
        _rawGyroRotation.rotation = transform.rotation;
        _rawGyroRotation.position = transform.position;

        yield return new WaitForSeconds(1);
        StartCoroutine(CalibrateYAngle());
    }

    private void Update()
    {
        HandleMovement();
        Vector3 direction = playerCam.transform.forward;
        playerRay = new Ray(playerCam.transform.position, direction);
        if (Physics.Raycast(playerRay, out visionHit, visionRange, hitLayer))
        {
            //Parte interactiva si es nota
            if (visionHit.collider.CompareTag("Note"))
            {
                pickUpUIFeedback.SetActive(true);

                /*if (Input.GetKeyDown(KeyCode.E))
                {
                    pickUpUIFeedback.SetActive(false);
                    ReadNoteData currentNote = visionHit.collider.GetComponent<ReadNoteData>();
                    int noteNumber = currentNote.noteNumber;
                    notesUI[noteNumber].gameObject.SetActive(true);
                    Numbers currentNumeros = visionHit.collider.GetComponent<Numbers>();
                    int numeros = currentNumeros.numeros;
                    numeroUI[numeros].gameObject.SetActive(true);
                }*/
            }
            /*if (visionHit.collider.CompareTag("Keypad"))
            {

                if(Input.GetKeyDown(KeyCode.E)) 
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    keypadPanel.SetActive(true);
                    playerController.canMove = false;

                }
            */
        }
        else
        {
            pickUpUIFeedback.SetActive(false);

            foreach (GameObject go in notesUI)
            {
                go.SetActive(false);
            }

        }

        // Apply gyroscope-based rotation
        if (_rawGyroRotation != null)
        {
            ApplyGyroRotation();
            ApplyCalibration();
            transform.rotation = Quaternion.Slerp(transform.rotation, _rawGyroRotation.rotation, _smoothing);
        }

        if (moveDirection.magnitude > 0.1f)
        {
            footstepsSound.enabled = true;
        }
        else
        {
            footstepsSound.enabled = false;
        }

    }

    private IEnumerator CalibrateYAngle()
    {
        float _tempSmoothing = _smoothing;
        _smoothing = 1;
        _calibrationYAngle = _appliedGyroAngle - _initialYAngle;
        yield return null;
        _smoothing = _tempSmoothing;
    }

    private void ApplyGyroRotation()
    {
        _rawGyroRotation.rotation = Input.gyro.attitude;
        _rawGyroRotation.Rotate(0f, 0f, 180f, Space.Self);
        _rawGyroRotation.Rotate(90f, 180f, 0f, Space.World);
        _appliedGyroAngle = _rawGyroRotation.eulerAngles.y;
    }


    private void ApplyCalibration()
    {
        _rawGyroRotation.Rotate(0f, -_calibrationYAngle, 0f, Space.World);
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.started && visionHit.collider.CompareTag("Note"))
        {
            pickUpUIFeedback.SetActive(false);
            ReadNoteData currentNote = visionHit.collider.GetComponent<ReadNoteData>();
            int noteNumber = currentNote.noteNumber;
            notesUI[noteNumber].gameObject.SetActive(true);
        }
    }

    private void HandleMovement()
    {
        if (controller != null)
        {
            Vector2 inputVector = moveAction.ReadValue<Vector2>(); // Joystick input

            // Asegúrate de que el eje Y del joystick está en el rango [-1, 1]
            float moveX = inputVector.x; // Izquierda/derecha
            float moveZ = inputVector.y; // Adelante/atrás

            // Obtiene la dirección de la cámara
            Vector3 joystickMove = new Vector3(inputVector.x, 0, inputVector.y) * speed * Time.deltaTime; Vector3 cameraForward = playerCam.transform.forward;
            Vector3 gyroMove = new Vector3(Input.acceleration.x * speed * Time.deltaTime, 0, -Input.acceleration.z * speed * Time.deltaTime);

            // Combine joystick and gyroscope movement
            Vector3 totalMove = joystickMove + transform.TransformDirection(gyroMove);
            cameraForward.y = 0; // Ignora el movimiento vertical
            cameraForward.Normalize();

            // Obtiene la derecha de la cámara
            Vector3 cameraRight = playerCam.transform.right;

            // Calcula la dirección total de movimiento
            Vector3 moveDirection = (cameraRight * moveX + cameraForward * moveZ).normalized;

            // Aplica el movimiento usando CharacterController
            controller.Move(moveDirection * speed * Time.deltaTime);
        }
    }
}