using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class GameOver : MonoBehaviour
{
    public float endTime;
    public TextMeshProUGUI returnTime;
    public TextMeshProUGUI hiScore;
    // Start is called before the first frame update
    void Start()
    {
        hiScore.text = PublicVars.highScore.ToString();
        endTime += Time.time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Time.time > endTime)
        {
            SceneManager.LoadScene("Title");
        }
        int result = (int)(endTime - Time.time) + 1;
        returnTime.text = result.ToString();

    }
}
