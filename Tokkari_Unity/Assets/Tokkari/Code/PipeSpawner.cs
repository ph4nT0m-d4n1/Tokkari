using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float timeDelay = 3.0f;
    [SerializeField] private float heightRange = 0.45f;
    [SerializeField] private GameObject iceberg;

    private float timer;
    void Start()
    {
        SpawnBerg();
    }

    private void Update()
    {
        if(timer > timeDelay) 
        {
            SpawnBerg();
            timer = 0;
        }

        timer += Time.deltaTime;
    }

    private void SpawnBerg()
    {
        Vector3 spawn = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange));
        GameObject newIceberg = Instantiate(iceberg, spawn, Quaternion.identity);

        Destroy(newIceberg, 10f);
    }
}
