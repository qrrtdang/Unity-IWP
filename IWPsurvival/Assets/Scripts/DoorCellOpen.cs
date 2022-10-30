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

    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    void OnMouseOver()
    {
        if (TheDistance <= 3)
        {
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
            Debug.Log("NearDoor");
        }
        //if (Input.GetButtonDown("E"))
        //{
        //    if (TheDistance <= 3)
        //    {
        //        this.GetComponent<BoxCollider>().enabled = false;
        //        ActionDisplay.SetActive(false);
        //        ActionText.SetActive(false);
        //        TheDoor.GetComponent<Animation>().Play("FirstDoorOpenAnim");
        //        creaksound.Play();
        //        Debug.Log("DoorOpened");
        //    }
        //}
    }

    
    void OnMouseExit()
    {
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }

   
}