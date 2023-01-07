using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        
        
        StartCoroutine(LoadGame());
        GlobalHealth.currentHealth = 100;
    }

    IEnumerator LoadGame()
    {
        yield return new WaitForSeconds(1.0f);
        if (SceneEntered.sceneNumber==2)
        {
            SceneManager.LoadScene(2);
            SceneEntered.sceneNumber = 0;
        }
        else if (SceneEntered.sceneNumber == 4)
        {
            SceneManager.LoadScene(4);
            SceneEntered.sceneNumber = 0;
        }
    }
}
