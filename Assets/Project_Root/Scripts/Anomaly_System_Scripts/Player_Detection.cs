using System.Collections.Generic;
using UnityEngine;

public class Player_Detection : MonoBehaviour
{
    [SerializeField] private List<AnomalySystem> materialchangeScripts = new List<AnomalySystem>();
    [SerializeField] private List<PositionChange> positionchangeScripts = new List<PositionChange>();
    [SerializeField] private List<RotationChange> rotationchangeScripts = new List<RotationChange>();

    private bool PlayerDetected = false;
    private int entryCount = 0;
    private bool tasksTriggered = false;

    void Start()
    {
        
        GameObject anomalyParentObject = GameObject.Find("MaterialChangeProps");
        if (anomalyParentObject != null)
        {
            materialchangeScripts.AddRange(anomalyParentObject.GetComponentsInChildren<AnomalySystem>());
        }
        else
        {
            Debug.LogWarning("No Object found");
        }

        // Find child scripts for position change
        GameObject positionParentObject = GameObject.Find("PositionChangeProps");
        if (positionParentObject != null)
        {
            positionchangeScripts.AddRange(positionParentObject.GetComponentsInChildren<PositionChange>());
        }
        else
        {
            Debug.LogWarning("No POsition  object found.");
        }

        // Find child scripts for rotation change
        GameObject rotationParentObject = GameObject.Find("RotationChangeProps");
        if (rotationParentObject != null)
        {
            rotationchangeScripts.AddRange(rotationParentObject.GetComponentsInChildren<RotationChange>());
        }
        else
        {
            Debug.LogWarning("No RotationChangeProps object found.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !tasksTriggered)
        {
            entryCount++;
            Debug.Log("Player contact count: " + entryCount);

            if (entryCount == 2)
            {
                tasksTriggered = true; 
                PlayerDetected = true;

    

                foreach (var materialChangeScript in materialchangeScripts)
                {
                    Debug.Log("Material change:  " + materialChangeScript.gameObject.name);
                    materialChangeScript.MaterialCounter();
                }
                foreach (var positionChangeScript in positionchangeScripts)
                {
                    Debug.Log("Position change: " + positionChangeScript.gameObject.name);
                    positionChangeScript.PositionCounter();
                }
                foreach (var rotationChangeScript in rotationchangeScripts)
                {
                    Debug.Log("Rotation Change: " + rotationChangeScript.gameObject.name);
                    rotationChangeScript.RotationCounter();
                }
            }
        }
    }

    public bool IsPlayerDetected()
    {
        return PlayerDetected;
    }
}