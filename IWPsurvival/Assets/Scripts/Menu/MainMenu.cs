using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject fadeOut;
    public GameObject loadText;
    public void NewGameButton()
    {
        StartCoroutine(NewGameStart());
    }
    IEnumerator NewGameStart()
    {

        fadeOut.SetActive(true);
        yield return new WaitForSeconds(3);
        loadText.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(3);
    }

}
