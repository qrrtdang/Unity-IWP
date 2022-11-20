using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GlobalHealth : MonoBehaviour
{

    public static int currentHealth = 500;
    public int internalHealth;
    public GameObject HealthDisplay;


    // Update is called once per frame
    void Update()
    {
        internalHealth = currentHealth;
        HealthDisplay.GetComponent<Text>().text = ""+ internalHealth;
        if(currentHealth<=0)
        {
            SceneManager.LoadScene(1);
            Debug.Log("Player is DEAD");
        }
    }
}
