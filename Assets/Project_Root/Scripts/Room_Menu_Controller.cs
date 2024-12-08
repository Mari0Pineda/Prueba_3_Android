using System;
using UnityEngine;
using UnityEngine.UI;

public class Room_Menu_Controller : MonoBehaviour
{
    [SerializeField] private Toggle[] toggles;
    public GameObject Room_1;
    public GameObject Room_2;
    public GameObject Room_3;
    public GameObject Location_Menu;
    public Player_Movement_Script playerMovement;

    private void Start()
    {
        foreach (Toggle toggle in toggles)
        {
            toggle.onValueChanged.AddListener(OnToggleChanged);
            toggle.isOn = false;
        }

        // Reference the Player_Movement_Script
        playerMovement = FindObjectOfType<Player_Movement_Script>();
        if (playerMovement == null)
            Debug.LogError("Player_Movement_Script is missing in the scene!");
    }

    public void ShowMenu()
    {
        Location_Menu.SetActive(true); // Show the menu
        playerMovement.ToggleMenu(true); // Inform player controller
    }

    public void HideMenu()
    {
        Location_Menu.SetActive(false); // Hide the menu
        playerMovement.ToggleMenu(false);
    }

    private void OnToggleChanged(bool isOn)
    {
        if (isOn)
        {
            // Turn off all other toggles
            foreach (Toggle toggle in toggles)
            {
                if (toggle != toggles[Array.IndexOf(toggles, toggle)])
                {
                    toggle.isOn = false;
                }
            }
        }
    }
    public void OnRightSlideButton()
    {
        if (toggles[0].isOn)
        { 
            ActivateRoom1();
            playerMovement.ToggleMenu(true);


        }

        else if (toggles[1].isOn)
        {
            ActivateRoom2();
            playerMovement.ToggleMenu(true);

        }

        else if (toggles[2].isOn)
        {
            ActivateRoom3();
            playerMovement.ToggleMenu(true);

        }
        else
        {
            Debug.LogWarning("Select Room");
        }
    }

    public void ActivateRoom1()
    {
        Room_1.SetActive(true);
        Room_2.SetActive(false);
        Room_3.SetActive(false);
        HideMenu(); // Close menu
    }

    public void ActivateRoom2()
    {
        Room_2.SetActive(true);
        Room_1.SetActive(false);
        Room_3.SetActive(false);
        HideMenu(); // Close menu
    }

    public void ActivateRoom3()
    {
        Room_3.SetActive(true);
        Room_1.SetActive(false);
        Room_2.SetActive(false);
        HideMenu(); // Close menu
    }
    public void Activate_Location_Menu()
    {
        Room_1.SetActive(false);
        Room_2.SetActive(false);
        Room_3.SetActive(false);
        Location_Menu.SetActive(true);

    }
    public void ButtMenuClosed()
    {
        Room_1.SetActive(false);
        Room_2.SetActive(false);
        Room_3.SetActive(false);
        Location_Menu.SetActive(false);
        playerMovement.ToggleMenu(false);
    }
}