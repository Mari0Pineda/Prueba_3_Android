using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Canvas_trigger : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject AnomalyUIHolder;
    void Start()
    {
        AnomalyUIHolder.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {

    
        if (other.CompareTag("Player"))

        {
            Debug.Log("Contact ");
            AnomalyUIHolder.SetActive(true);
        }
    }
}
