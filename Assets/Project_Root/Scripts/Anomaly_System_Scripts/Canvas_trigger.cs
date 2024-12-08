using UnityEngine;

public class Canvas_trigger : MonoBehaviour
{
    [SerializeField] private GameObject AnomalyUIHolder; // Reference to the UI canvas
    public Player_Movement_Script playerMovement;       // Reference to the player's movement script
    

    void Start()
    {

        AnomalyUIHolder.SetActive(false);

        // Find the Player_Movement_Script in the scene
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerMovement = player.GetComponent<Player_Movement_Script>();
        }

        if (playerMovement == null)
        {
            Debug.LogError("Player_Movement_Script not found on Player!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            Debug.Log("Contact with Player");

            // Activate the UI canvas
            AnomalyUIHolder.SetActive(true);

            // Notify the player movement script to disable player controls and unlock the cursor
            if (playerMovement != null)
            {
                playerMovement.ToggleMenu(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the player leaves the trigger
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player left trigger");

            // Deactivate the UI canvas
            AnomalyUIHolder.SetActive(false);

            // Notify the player movement script to re-enable controls and lock the cursor
            if (playerMovement != null)
            {
                playerMovement.ToggleMenu(false);
            }
        }
    }
}