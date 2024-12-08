using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BergSpawner : MonoBehaviour
{
    public float timeDelay = 3.0f; //delay in-between iceberg spawns
    public GameObject iceberg; //object to be spawned   
    public float heightRange = 0.45f; //difference in Y value for iceberg pair
    public float destroyTimer = 22f; //destroy after this many seconds

    private float timer;
    void Start()
    {
        SpawnBerg(); //spawn upon start
    }

    void Update()
    {
        if(timer > timeDelay) //if timer exceeds the delay, then spawnBerg is called
        {
            SpawnBerg();
            timer = 0;
        }

        timer += Time.deltaTime; //time is incremented by "seconds from last frame to current frame" -unity manual
    }

    void SpawnBerg()
    {
        //update position, randomizing the height (y value)
        //Random.range is used and returns a number between -heightRange, heightRange...
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange));
        
        //instantiate the object (iceberg)
        GameObject newIceberg = Instantiate(iceberg, spawnPos, Quaternion.identity);

        //destroy object after set amount of time
        Destroy(newIceberg, destroyTimer);
    }
}
