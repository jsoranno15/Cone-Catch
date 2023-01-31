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
    public Text scoreOut;
    public Text lifeOut;
    // Start is called before the first frame update
    void Start()
    {
        triangleRB = GetComponent<Rigidbody2D>();
        score = 0;
        life = 3;
        
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
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Hit");
        if(col.gameObject.tag == "circle")
        {
            score++;
            scoreOut.text = score.ToString();
            Debug.Log("circle");
        }
        if (col.gameObject.tag == "square")
        {
            life--;
            lifeOut.text = life.ToString();
            Debug.Log("square");
            if (life == 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
        Destroy(col.gameObject);
    }
}
