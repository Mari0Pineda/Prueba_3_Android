using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement_Script : MonoBehaviour
{

    private bool isMenuActive = false;
   

   
    private void Start()
    {
        // Lock the cursor to the center of the screen and hide it
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (isMenuActive)
        {
            // Unlock the cursor when the menu is active
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            Debug.Log("Menu active: Cursor unlocked");
            return; // Skip player controls while menu is active
        }
        else
        {
            // Lock the cursor when the menu is not active
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            Debug.Log("Menu inactive: Cursor locked");
        }

    }
    public void ToggleMenu(bool menuActive)
    {
        isMenuActive = menuActive;
    }
}