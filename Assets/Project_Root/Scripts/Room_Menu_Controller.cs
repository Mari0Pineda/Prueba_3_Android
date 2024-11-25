using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

//ACTIVATE Room only .  Room menu
public class Room_Menu_Controller : MonoBehaviour
{

    // Start is called before the first frame update
    [SerializeField] private Toggle[] toggles;
    public GameObject Room_1;
    public GameObject Room_2;
    public GameObject Room_3;
    public GameObject Location_Menu;

    private void Start()
    {
        foreach (Toggle toggle in toggles)
        {
            toggle.onValueChanged.AddListener(OnToggleChanged);
            toggle.isOn = false;
        }
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
        { ActivateRoom1(); }

        else if (toggles[1].isOn)
        { ActivateRoom2(); }

        else if (toggles[2].isOn)
        { ActivateRoom3(); }
        else
        {
            Debug.LogWarning("Select Room");
        }
    }

    //EACH ROOM FUNCT
    public void ActivateRoom1()
    {
        // Set Room_1 to active, and hide other rooms or menus if neede
        Room_1.SetActive(true);
        Room_2.SetActive(false);
        Room_3.SetActive(false);
        Location_Menu.SetActive(false);
    }
    public void ActivateRoom2()
    {
        Room_2.SetActive(true);
        Room_1.SetActive(false);
        Room_3.SetActive(false);
        Location_Menu.SetActive(false);
    }
    public void ActivateRoom3()
    {
        Room_3.SetActive(true);
        Room_1.SetActive(false);
        Room_2.SetActive(false);
        Location_Menu.SetActive(false);
    }

    //Left slide button for room menu active.
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
    }

}
