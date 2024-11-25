using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelControl : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] PlayerController playerController;
    [SerializeField] GameObject panelControl;

    public List<GameObject> rooms;
    public int roomSelected;
    public PanelControl other_button;

    public void nextRoom()
    {
        roomSelected = roomSelected + 1;
        if(roomSelected > rooms.Count - 1)
        {
            roomSelected = 0;
        }
        if (roomSelected > 0)
        {
            rooms[roomSelected - 1].SetActive(false);
        }
        if(roomSelected == 0)
        {
            rooms[rooms.Count - 1].SetActive(false);
        }
        rooms[roomSelected].SetActive(true);
        other_button.roomSelected = roomSelected;
        Debug.Log(roomSelected);
    }

    public void previousRoom()
    {
        roomSelected = roomSelected - 1;
        if (roomSelected < 0)
        {
            roomSelected = rooms.Count -1;
        }
        if (roomSelected == rooms.Count -1)
        {
            rooms[0].SetActive(false);
        }
        if (roomSelected < rooms.Count -1)
        {
            rooms[roomSelected +1].SetActive(false);
        }
        rooms[roomSelected].SetActive(true);
        other_button.roomSelected = roomSelected;
        Debug.Log(roomSelected);
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
