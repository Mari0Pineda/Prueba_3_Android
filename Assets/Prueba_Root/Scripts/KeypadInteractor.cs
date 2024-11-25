using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KeypadInteractor : MonoBehaviour
{

    [Header("Exit Keypad Variables")]
    [SerializeField] GameObject player;
    [SerializeField] FPSController playerController;
    [SerializeField] GameObject keypad;
    
    public Text text;
    public string respuestas = "0763";
    public AudioSource incorrecto;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<FPSController>();
        gameObject.SetActive(false);
    }

    public void Number(int number)
    {
        text.text += number.ToString();

    }

    public void Execute()
    {
        if (text.text == respuestas)
        {
            text.text = "Correcto";
        } else
        {
            text.text = "Incorrecto";
            incorrecto.Play();
            
        }
    }

    public void Clear()
    {
        text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (text.text == "Correcto")
        {
            SceneManager.LoadScene("Win");
        }
    }

    public void ExitKeypad()
    {
        playerController.canMove = true; ;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gameObject.SetActive(false);
    }
}
