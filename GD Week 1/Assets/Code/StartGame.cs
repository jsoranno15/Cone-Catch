using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetButtonDown("Switch"))
        {
            GameStart();
        }
    }

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
