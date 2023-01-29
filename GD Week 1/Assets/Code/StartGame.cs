using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    public void GameStart()
    {
        SceneManager.LoadScene("Game");
    }

    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }
    public void BackToTitle()
    {
        SceneManager.LoadScene("Title");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
