using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Referencias privadas
    Ray playerRay;
    RaycastHit visionHit;
    //Rigidbody playerRb;
    PlayerInput playerInput;
    //Vector3 moveInput;

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
    //[SerializeField] float speed;
    public bool onInteract;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        //playerRb = GetComponent<Rigidbody>();
        //playerRb.velocity = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
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

    }
    /*private void FixedUpdate()
    {
        playerRb.velocity = new Vector3(moveInput.x * speed, playerRb.velocity.y, moveInput.y * speed);
    }

    public void Move(InputAction.CallbackContext context)
    {
        //A la variable constante de Vector2 que va a definir la dirección del jugador, le pasaremos el valor del joystick
        moveInput = context.ReadValue<Vector2>();
    }*/

    public void OnInteract(InputAction.CallbackContext context)
    {
        if(context.started && visionHit.collider.CompareTag("Note"))
        {
            pickUpUIFeedback.SetActive(false);
            ReadNoteData currentNote = visionHit.collider.GetComponent<ReadNoteData>();
            int noteNumber = currentNote.noteNumber;
            notesUI[noteNumber].gameObject.SetActive(true);
        }
    }
}
