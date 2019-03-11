using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public Transform[] spawnPoints;
    public float spawnTime = 1f;


    //public GameObject objects;
    public GameObject[] objects;

    void Start()
    {
        InvokeRepeating("Spawnobjects", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawnobjects()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        int spawnIndex2 = Random.Range(0, spawnPoints.Length);

        int objectsIndex = Random.Range(0, objects.Length);
        int objectsIndex2 = Random.Range(0, objects.Length);

        Instantiate(objects[objectsIndex], spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
        Instantiate(objects[objectsIndex2], spawnPoints[spawnIndex2].position, Quaternion.Euler(0,0,90));
    }
}
