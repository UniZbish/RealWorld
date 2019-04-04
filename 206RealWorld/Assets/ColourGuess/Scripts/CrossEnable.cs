using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossEnable : MonoBehaviour {

    public GameObject controller;
    public int enableNum;
	
	// Update is called once per frame
	void Update () {
	    if (controller.GetComponent<generateGrid>().elimCount == enableNum)
        {
            GetComponent<Image>().enabled = true;
        }
	}
}
