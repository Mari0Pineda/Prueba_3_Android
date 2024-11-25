using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionChange : MonoBehaviour
{

    [SerializeField] Vector3 initialPosition;
    [SerializeField] public Vector3 newPosition;
    [SerializeField] float PositionDelayTime;
   
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
       // initialRotation = transform.rotation;
    }


    private void ChangePosition()
    {
        transform.localPosition = newPosition;
        //transform.rotation = Quaternion.Euler(newRotation);
    }
    public void PositionCounter() 
    {
        Invoke(nameof(ChangePosition),PositionDelayTime);
        Debug.Log("Position initializedfor"+ gameObject.name);
    }
    
}
