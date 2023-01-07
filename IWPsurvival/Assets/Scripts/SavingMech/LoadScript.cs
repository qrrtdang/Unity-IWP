using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScript : MonoBehaviour
{
    public GameObject loadButton;
    public int loadInt;
    void Start()
    {
        loadInt = PlayerPrefs.GetInt("AutoSave");
        if(loadInt >0)
        {
            loadButton.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
