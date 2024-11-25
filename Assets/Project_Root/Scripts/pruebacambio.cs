using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pruebacambio : MonoBehaviour
{
    public float tiempo_start;
    public float tiempo_end;
    // Start is called before the first frame update
    private void Update()
    {
        tiempo_start += Time.deltaTime;
        if (tiempo_start >= tiempo_end)
        {
            SceneManager.LoadScene("menu");

        }
    }
}
