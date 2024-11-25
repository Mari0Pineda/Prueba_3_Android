using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class AnomalySystem : MonoBehaviour
{
    //                                         Initial position,rotation,texture fields     //
    [SerializeField] GameObject Prop;

    //[SerializeField] GameObject anomalyObject; //Mightnot need it.
    //material
    [SerializeField] Material originalMaterial;
    [SerializeField] Material AnomalyMaterial;
    //
  
    [SerializeField] bool anomalyActivated;

    //Mesh fields
    
    MeshRenderer modelRend;
    //Counter fields
    [SerializeField] float MatChange_waitTime;
    private int entryCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        

        //Material Render

        modelRend = Prop.GetComponent<MeshRenderer>();

        if (modelRend == null)
        {
            Debug.LogError("MeshRenderer not found on startObject!");
        }
        else
        {
            Debug.Log("MeshRenderer found: " + modelRend.name);
        }

        if (modelRend != null && originalMaterial != null)
        {
            modelRend.material = originalMaterial;
            Debug.Log("Original material intialized");
        }


    }

    // Update is called once per frame
    void Update()
    {
    }



    private void ChangeTexture()
    {

        if (modelRend != null && AnomalyMaterial != null)
        {
            modelRend.material = AnomalyMaterial;
            Debug.Log("Material changed to anomaly material!");
        }
        else
        {
            Debug.LogError("Material is null!");
        }
    }
    public void MaterialCounter() 
    {
        Invoke(nameof(ChangeTexture),MatChange_waitTime);
        Debug.Log("Material change countdown started");
    }
  
}
