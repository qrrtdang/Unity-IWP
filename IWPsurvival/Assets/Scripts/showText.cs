using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showText : MonoBehaviour
{
    public GameObject TextBox;
    public string Dialogue;
    public float TimeShownOnScreen;

    void OnTriggerEnter(Collider other)
    {
        this.GetComponent<BoxCollider>().enabled = false;
        StartCoroutine(ScenePlayer());
    }

    IEnumerator ScenePlayer()
    {
        TextBox.GetComponent<Text>().text = Dialogue;
        yield return new WaitForSeconds(TimeShownOnScreen);
        TextBox.GetComponent<Text>().text = "";
    }
}
