using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tiempo : MonoBehaviour
{
    public float tiempo_start; 
    public float tiempo_end;
                             
    void Update()
    {
        tiempo_start += Time.deltaTime;
        if (tiempo_start >= tiempo_end) 
        {
            SceneManager.LoadScene("Backroom");
        }
    }
}