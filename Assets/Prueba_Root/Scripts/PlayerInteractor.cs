using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class PlayerInteractor : MonoBehaviour
{
    Ray playerRay;
    RaycastHit visionHit;
    FPSController playerController;

    [Header("Raycasting Data")]
    [SerializeField] private Camera playerCam;
    [SerializeField] float visionRange;
    [SerializeField] LayerMask hitLayer;

    

    [Header("Visual Feedback")]
    [SerializeField] GameObject pickUpUIFeedback;
    [SerializeField] GameObject[] notesUI;
    //[SerializeField] GameObject keypadPanel;

    [Header("Numeros")]
    [SerializeField] GameObject[] numeroUI;

    private void Start()
    {
        playerController = GetComponent<FPSController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = playerCam.transform.forward;
        playerRay = new Ray(playerCam.transform.position, direction);

        if(Physics.Raycast(playerRay,out visionHit, visionRange,hitLayer))
        {
            //Parte interactiva si es nota
            if (visionHit.collider.CompareTag("Note"))
            {
                pickUpUIFeedback.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    pickUpUIFeedback.SetActive(false);
                    ReadNoteData currentNote = visionHit.collider.GetComponent<ReadNoteData>();
                    int noteNumber = currentNote.noteNumber;
                    notesUI[noteNumber].gameObject.SetActive(true);
                    Numbers currentNumeros = visionHit.collider.GetComponent<Numbers>();
                    int numeros = currentNumeros.numeros;
                    numeroUI[numeros].gameObject.SetActive(true);
                }
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
}
