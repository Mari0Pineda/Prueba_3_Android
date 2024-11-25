using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationChange : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField] Quaternion initialRotation;
   [SerializeField] public Vector3 newRotation;
   [SerializeField] float RotationDelayTime;
    // Start is called before the first frame update
    void Start()
    {
        initialRotation = transform.rotation;
        // initialRotation = transform.rotation;
    }


    private void ChangeRotation()
    {
        
        transform.localRotation = Quaternion.Euler(newRotation);
    }
    public void RotationCounter()
    {
        Invoke(nameof(ChangeRotation), RotationDelayTime);
        Debug.Log("Rotation initialized for"+ gameObject.name);
    }
}
