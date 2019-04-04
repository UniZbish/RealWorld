using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects1 : MonoBehaviour
{
    public Transform[] spawnPoints;
    public float spawnTime = 2.5f;


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


        int objectsIndex = Random.Range(0, objects.Length);

        Instantiate(objects[objectsIndex], spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
    }
}
