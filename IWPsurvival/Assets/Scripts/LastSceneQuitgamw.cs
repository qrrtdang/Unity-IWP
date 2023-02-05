using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastSceneQuitgamw : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(quitgame());
    }

    IEnumerator quitgame()
    {
        yield return new WaitForSeconds(41.1f);
        Debug.Log("quit success");
        Application.Quit();
    }
        
}
