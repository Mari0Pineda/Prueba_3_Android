using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Anomaly_List_Controller : MonoBehaviour
{
    [SerializeField] private Toggle[] toggles;
    [SerializeField] private GameObject[] targetObjects;
    [SerializeField] private TMP_Text countText;

    private void Start()
    {
        for (int i = 0; i < toggles.Length; i++)
        {
            toggles[i].onValueChanged.AddListener(OnToggleChanged);
            toggles[i].isOn = false;
            if (i < targetObjects.Length)
            {
                targetObjects[i].SetActive(true);
            }
        }

        UpdateCountDisplay();
    }

    private void OnToggleChanged(bool isOn)
    {
        for (int i = 0; i < toggles.Length && i < targetObjects.Length; i++)
        {
            targetObjects[i].SetActive(!toggles[i].isOn);
        }

        UpdateCountDisplay();
    }

    private void UpdateCountDisplay()
    {
        int count = 0;

        foreach (Toggle toggle in toggles)
        {
            if (toggle.isOn) count++;
        }

        countText.text = $"{count}/{toggles.Length}";

        if (count == toggles.Length)
        {
            StartCoroutine(LoadSceneAfterDelay(3));
        }
    }

    private IEnumerator LoadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("victoria");
    }

    private void OnDestroy()
    {
        foreach (Toggle toggle in toggles)
        {
            toggle.onValueChanged.RemoveListener(OnToggleChanged);
        }
    }
}