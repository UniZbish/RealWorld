using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryTime1 : MonoBehaviour
{

    public float destroyTime = 3.5f;

    void Start()
    {
        Destroy(gameObject, destroyTime);
    }
}
