using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle : MonoBehaviour
{
    Rigidbody2D triangleRB;
    public float xposition;
    // Start is called before the first frame update
    void Start()
    {
        triangleRB = GetComponent<Rigidbody2D>();
        
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
}
