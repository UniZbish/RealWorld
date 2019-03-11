using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoremanager : MonoBehaviour
{
    public int firstPlacePoints = 30, secondPlacePoints = 25, thirdPlacePoints = 15, fourthPlacePoints = 5;
    public int firstPlace, secondPlace, thirdPlace, fourthPlace;

    private void Awake()
    {
        DontDestroyOnLoad(this.transform);
    }
}
