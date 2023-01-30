using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour
{
    public GameObject cirlcePrefab;
    public GameObject squarePrefab;
    public float objectCooldown;
    float nextObject;
    // Start is called before the first frame update
    void Start()
    {
        nextObject = Time.time + objectCooldown;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int value = Random.Range(1, 3);
        if(Time.time > nextObject && value == 1)
        {
            GameObject newCircle = Instantiate(cirlcePrefab, transform.position, Quaternion.identity);
            float randomCDMod = Random.Range(-1.0f, 2.0f);
            objectCooldown += randomCDMod;
            nextObject = Time.time + objectCooldown;
            objectCooldown -= randomCDMod;
        }
        if (Time.time > nextObject && value == 2)
        {
            GameObject newSquare = Instantiate(squarePrefab, transform.position, Quaternion.identity);
            float randomCDMod = Random.Range(-1.0f, 2.0f);
            objectCooldown += randomCDMod;
            nextObject = Time.time + objectCooldown;
            objectCooldown -= randomCDMod;
        }
    }
}
