using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateUI : MonoBehaviour
{
    public GameObject DesiredUI;
    // Start is called before the first frame update
    void OnTriggerEnter()
    {
        DesiredUI.SetActive(true);
    }
}
