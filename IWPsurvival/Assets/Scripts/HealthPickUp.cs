using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HealthPickUp : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject ExtraCross;
    public GameObject AmmoDisplayBox;

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
            Debug.Log("NearHealth");
        }
        if (Input.GetButtonDown("Interact"))
        {
            if (TheDistance <= 3)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                gameObject.SetActive(false);
                ExtraCross.SetActive(false);
                AmmoDisplayBox.SetActive(true);
                if(GlobalHealth.currentHealth<=85)
                {
                    GlobalHealth.currentHealth += 15;
                }
                else if(GlobalHealth.currentHealth >85)
                {
                    int n;
                    n = 100 - GlobalHealth.currentHealth;
                    GlobalHealth.currentHealth += n;
                }
                
                Debug.Log("GotHealth");

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
