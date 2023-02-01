using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Triangle : MonoBehaviour
{
    Rigidbody2D triangleRB;
    public float xposition;
    int score;
    int life;
    bool invuln = false;
    float invulnTime = 0.0f;
    ScreenShake shake;
    public TextMeshProUGUI scoreOut;
    public TextMeshProUGUI lifeOut;

    // Start is called before the first frame update
    void Start()
    {
        triangleRB = GetComponent<Rigidbody2D>();
        score = 0;
        life = 3;
        shake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ScreenShake>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Switch"))
        {
            // triangleRB.AddForce(new Vector2(velocity, 0));
            //transform.position = new Vector2(transform.position.x + xposition * Time.deltaTime, -3);
            transform.Translate(xposition , 0,0);
            xposition = xposition * -1;
        }

        if (invulnTime > 0)
        {
            invulnTime -= Time.deltaTime;
            if (invulnTime <= 0)
            {
                invuln = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "circle")
        {
            score++;
            scoreOut.text = score.ToString();
        }
        if (col.gameObject.tag == "square" && invuln == false)
        {
            shake.ShakeTrigger();
            if(PublicVars.highScore < score)
            {
                PublicVars.highScore = score;
            }
            life--;
            lifeOut.text = life.ToString();
            if (life == 0)
            {
                SceneManager.LoadScene("GameOver");
            }
            invulnTime = 2.0f;
            invuln = true;
        }
        Destroy(col.gameObject);
    }
}
