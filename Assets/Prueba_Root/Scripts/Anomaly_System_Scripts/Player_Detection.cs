using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Detection : MonoBehaviour
{
    
   
    [SerializeField] private List<AnomalySystem> materialchangeScripts = new List<AnomalySystem>();
    [SerializeField] private List<PositionChange>  positionchangeScripts = new List<PositionChange>();
    [SerializeField] private List<RotationChange> rotationchangeScripts = new List<RotationChange>();
    
    // Start is called before the first frame update
    private int entryCount = 0;
    void Start()
    {
                                         //MATERIAL CHANGE
           GameObject anomalyParentObject = GameObject.Find("MaterialChangeProps");
        if (anomalyParentObject != null) 
        {
            AnomalySystem[] childAnomalyScripts = anomalyParentObject.GetComponentsInChildren<AnomalySystem>();
            materialchangeScripts.AddRange(childAnomalyScripts);
        }

        else if (materialchangeScripts.Count == 0) 
        {
            Debug.Log("No AnomalySystem (texturechange)script found in children");
        }

                                    //POSITION CHANGE
        GameObject positionParentObject = GameObject.Find("PositionChangeProps");
        if (positionParentObject != null)
        {
            PositionChange[] childPositionScripts = positionParentObject.GetComponentsInChildren<PositionChange>();
            positionchangeScripts.AddRange(childPositionScripts);
        }
        else if (positionchangeScripts.Count == 0) 
        {
            Debug.Log("No Position Change scripts found in PositionChangeProps'children");
        }
                                     //ROTATION CHANGE
        GameObject rotationParentObject  = GameObject.Find("RotationChangeProps");
        if(rotationParentObject != null)
        {
            RotationChange[] childRotationScripts = rotationParentObject.GetComponentsInChildren<RotationChange>();
            rotationchangeScripts.AddRange(childRotationScripts);    
        }

      
    }

   
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the player
        if (other.CompareTag("Player"))
        {
           
            Debug.Log("Player Detected");
         
            entryCount++;  
            Debug.Log("Contact count:" + entryCount);

            // countdown on the second time

            if (entryCount == 2)
            { 
                Debug.Log("Player contact #2 ...");
                //material change logic
                foreach (var materialChangeScript in materialchangeScripts)
                {
                    materialChangeScript.MaterialCounter();
                }
                
                //position change logic
                foreach (var positionChangeScript in positionchangeScripts)
                {
                    positionChangeScript.PositionCounter();   
                }
                //rotation change logic
                
                foreach(var rotationChangeScript in rotationchangeScripts) 
                { 
                    rotationChangeScript.RotationCounter();
                }
            }

        }
    }

}
