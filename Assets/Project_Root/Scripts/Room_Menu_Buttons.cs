using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room_Menu_Buttons : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Room_1;
    public GameObject Room_2;
    public GameObject Room_3;
    public GameObject Location_Menu;

    public void ActivateRoom1()
    {
        // Set Room_1 to active, and hide other rooms or menus if needed
        Room_1.SetActive(true);
        Location_Menu.SetActive(false);
    }
    public void ActivateRoom2()
    {
        Room_2.SetActive(true);
        Location_Menu.SetActive(false);
    }
    public void ActivateRoom3()
    {
        Room_3.SetActive(true);
        Location_Menu.SetActive(false);
    }
}
