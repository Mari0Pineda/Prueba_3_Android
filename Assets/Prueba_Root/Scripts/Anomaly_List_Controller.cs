using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class Anomaly_List_Controller : MonoBehaviour
{
    [SerializeField] private Toggle[] toggles;
    [SerializeField] private GameObject[] targetObjects;
    [SerializeField] private TMP_Text countText;
    /*  // Start is called before the first frame update
    public Toggle toggle;
    public Toggle toggle1;
    public Toggle toggle2;
    public Toggle toggle3;
    public Toggle toggle4;
    public Toggle toggle5;
    public Toggle toggle6;
    public Toggle toggle7;
    public GameObject targetObject;
    public GameObject targetObject1;
    public GameObject targetObject2;
    public GameObject targetObject3;
    public GameObject targetObject4;
    public GameObject targetObject5;
    public GameObject targetObject6;
    public GameObject targetObject7;
  */

    void Start()
    {
        foreach(Toggle toggle in toggles)
        {
            toggle.onValueChanged.AddListener(OnToggleChanged);
            toggle.isOn = false;
        }
        UpdateCountDisplay();
       /*
        toggle.onValueChanged.AddListener(OnToggleChanged);

        // make sure the toggle is off by default at the start
        toggle.isOn = false;
       */
    }

    // Method triggered when the Toggle is changed
    void OnToggleChanged(bool isOn)
    {
        for (int i = 0; i < toggles.Length && i < targetObjects.Length; i++)
        {
            targetObjects[i].SetActive(!toggles[i].isOn);
        }
        UpdateCountDisplay();
        /*if (isOn)
        {
            // If the toggle is turned on, reset the object's position
            /*targetObject.SetActive(false);
            targetObject1.SetActive(false);
            targetObject2.SetActive(false);
            targetObject3.SetActive(false);
            targetObject4.SetActive(false);
            targetObject5.SetActive(false);
            targetObject6.SetActive(false);
            targetObject7.SetActive(false);
            
        }*/
     /*else if (isOn != true)
        {
         /*   targetObject.SetActive(true);
            targetObject1.SetActive(true);
            targetObject2.SetActive(true);
            targetObject3.SetActive(true);
            targetObject4.SetActive(true);
            targetObject5.SetActive(true);
            targetObject6.SetActive(true);
            targetObject7.SetActive(true);
         
        }*/
    }
    private void UpdateCountDisplay() 
    {
    int count = 0;
        foreach (Toggle toggle in toggles)
        {
            if (toggle.isOn) count++; 
        }
        countText.text = $"{count}/{toggles.Length}";
        if (count == 8) 
        {
            SceneManager.LoadScene("victoria");
        }
    }
    private void OnDestroy()
    {
        foreach (Toggle toggle in toggles)
        {
            toggle.onValueChanged.RemoveListener(OnToggleChanged);
        }
    }










}
