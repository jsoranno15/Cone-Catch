using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectSpawn : MonoBehaviour
{
    public GameObject cirlcePrefab;
    public GameObject squarePrefab;
    public float objectCooldown;
    float nextObject;
    public TextMeshProUGUI scoreIn;
    public bool left;
    // Start is called before the first frame update
    void Start()
    {
        nextObject = Time.time + objectCooldown;
        if (left) {
            GameObject newCircle = Instantiate(cirlcePrefab, transform.position, Quaternion.identity);
            float randomCDMod = Random.Range(-1.0f, 2.0f);
            objectCooldown += randomCDMod;
            nextObject = Time.time + objectCooldown;
            objectCooldown -= randomCDMod;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int value = Random.Range(1, 3);
        int score = int.Parse(scoreIn.text);
        int force = score / 5;
        if(Time.time > nextObject && value == 1)
        {
            GameObject newCircle = Instantiate(cirlcePrefab, transform.position, Quaternion.identity);
            newCircle.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, force * 80));
            float randomCDMod = Random.Range(-0.5f, 1.5f);
            objectCooldown += randomCDMod;
            nextObject = Time.time + objectCooldown;
            Debug.Log(objectCooldown.ToString());
            objectCooldown -= randomCDMod;
        }
        if (Time.time > nextObject && value == 2)
        {
            GameObject newSquare = Instantiate(squarePrefab, transform.position, Quaternion.identity);
            newSquare.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, force * 40));
            float randomCDMod = Random.Range(-0.5f, 2.0f);
            objectCooldown += randomCDMod;
            nextObject = Time.time + objectCooldown;
            Debug.Log(objectCooldown.ToString());
            objectCooldown -= randomCDMod;
        }
    }
}
