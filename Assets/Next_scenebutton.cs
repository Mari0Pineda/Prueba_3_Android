using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneButton : MonoBehaviour
{
    public string nextSceneName = "escena1"; // The name of the next scene to load

    // This function can be assigned to a Button's OnClick event
    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}