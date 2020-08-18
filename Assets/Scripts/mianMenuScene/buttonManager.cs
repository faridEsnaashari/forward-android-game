using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonManager : MonoBehaviour
{
    public void loadPlayScene()
    {
        SceneManager.LoadScene("play" , LoadSceneMode.Single);
    }
    public void quitTheGame()
    {
        Application.Quit();
    }
    public void loadSettinScene()
    {
        SceneManager.LoadScene("setting" , LoadSceneMode.Single);
    }
}
