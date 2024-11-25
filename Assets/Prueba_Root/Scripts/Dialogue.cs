using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{

    public Text text08;
    public GameObject Activator;
    public string dialogue = "Dialogue";

    public float timer = 2f;

    // Start is called before the first frame update
    void Start()
    {
        text08.GetComponent<Text>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            text08.GetComponent<Text>().enabled = true;
            text08.text = dialogue.ToString();
            StartCoroutine(DissableText());
        }
    }
    IEnumerator DissableText()
    {
        yield return new WaitForSeconds(timer);
        text08.GetComponent<Text>().enabled = false;
        Destroy(Activator);
    }
}
