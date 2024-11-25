using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Quitar : MonoBehaviour
{
    // Start is called before the first frame update
  public void QuitarJuego()
    {
        Debug.Log("exit");
        Application.Quit();
    }
}
