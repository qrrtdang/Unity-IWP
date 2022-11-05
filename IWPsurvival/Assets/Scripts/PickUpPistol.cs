using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PickUpPistol : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject FakePistol;
    public GameObject RealPistol;
    public GameObject ExtraCross;

    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    void OnMouseOver()
    {
        if (TheDistance <= 3)
        {
            ExtraCross.SetActive(true);
            ActionText.GetComponent<Text>().text = "Pick Up";
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
            Debug.Log("NearPistol");
        }
        if (Input.GetButtonDown("Interact"))
        {
            if (TheDistance <= 3)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                FakePistol.SetActive(false);
                RealPistol.SetActive(true);
                Debug.Log("GotPistol");
            }
        }
        if (TheDistance >= 1.5)
        {
            ExtraCross.SetActive(false);
            ActionDisplay.SetActive(false);
            ActionText.SetActive(false);

        }
    }


    void OnMouseExit()
    {
        ExtraCross.SetActive(false);
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }
}
