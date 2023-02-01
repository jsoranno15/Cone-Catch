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
    Vector3 leftPos = new Vector3(-1.5f, -3.0f, 0.0f);
    Vector3 rightPos = new Vector3(1.5f, -3.0f, 0.0f);
    bool isLeft = true;
    float moveSpd = 30.0f;
    Vector3 oldPos;
    Vector3 currSpeed;

    // Start is called before the first frame update
    void Start()
    {
        triangleRB = GetComponent<Rigidbody2D>();
        score = 0;
        life = 3;
        shake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ScreenShake>();
        oldPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Switch"))
        {
            // triangleRB.AddForce(new Vector2(velocity, 0));
            //transform.position = new Vector2(transform.position.x + xposition * Time.deltaTime, -3);
            //transform.Translate(xposition , 0,0);
            //xposition = xposition * -1;
            isLeft = !isLeft;
        }

        float moveAmt = moveSpd * Time.deltaTime;
        currSpeed = oldPos - transform.position;
        oldPos = transform.position;

        if (isLeft)
        {
            transform.position = Vector3.MoveTowards(transform.position, leftPos, moveAmt);
            //transform.position = Vector3.Lerp(transform.position, leftPos, 0.5f);
            //transform.position = Vector3.SmoothDamp(transform.position, leftPos, ref currSpeed, 1.0f);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, rightPos, moveAmt);
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
