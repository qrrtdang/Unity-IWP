using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DoorCellOpen : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject TheDoor;
    public AudioSource creaksound;
    public GameObject ExtraCross;
    //public GameObject Test;

    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    void OnMouseOver()
    {
        if (TheDistance <= 3)
        {
            ExtraCross.SetActive(true);
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
            Debug.Log("NearDoor");
        }
        if (Input.GetButtonDown("Interact"))
        {
            if (TheDistance <= 3)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                TheDoor.GetComponent<Animation>().Play("FirstDoorOpenAnim");
                creaksound.Play();
                Debug.Log("DoorOpened");
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