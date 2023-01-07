using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject fadeOut;
    public GameObject loadText;

    public GameObject loadButton;
    public int loadInt;

    void Start()
    {
        loadInt = PlayerPrefs.GetInt("AutoSave");
        if (loadInt > 0)
        {
            loadButton.SetActive(true);
        }
    }
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
        SceneManager.LoadScene(6);
    }

    public void LoadGameButton()
    {
        StartCoroutine(LoadGameStart());
    }

    IEnumerator LoadGameStart()
    {

        fadeOut.SetActive(true);
        yield return new WaitForSeconds(3);
        loadText.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(loadInt);
    }

}
