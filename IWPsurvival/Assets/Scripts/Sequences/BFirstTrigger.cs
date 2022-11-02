using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BFirstTrigger : MonoBehaviour
{
    
    public GameObject TextBox;
    public string Dialogue;

    void OnTriggerEnter(Collider other)
    {
        StartCoroutine(ScenePlayer());
    }

    IEnumerator ScenePlayer()
    {
        TextBox.GetComponent<Text>().text = Dialogue;
        yield return new WaitForSeconds(3f);
        TextBox.GetComponent<Text>().text = "";
    }

    void OnTriggerExit(Collider other)
    {
        this.GetComponent<BoxCollider>().enabled = false;
    }
}
