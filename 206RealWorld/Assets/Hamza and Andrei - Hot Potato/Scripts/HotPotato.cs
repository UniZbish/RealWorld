using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotPotato : MonoBehaviour
{

    public GameObject player1, player2, player3, player4;


    RoundStart whoIsHot;


    // Start is called before the first frame update
    void Start()
    {
        whoIsHot = GameObject.Find("RoundStarter").GetComponent<RoundStart>();
    }

    // Update is called once per frame
    void Update()
    {
        PotatoAssigning();
    }

    private void PotatoAssigning()
    {
        if (whoIsHot.hotStarter == 1)
        {
            transform.position = player1.transform.position;
        }
        if (whoIsHot.hotStarter == 2)
        {
            transform.position = player2.transform.position;
        }
        if (whoIsHot.hotStarter == 3)
        {
            transform.position = player3.transform.position;
        }
        if (whoIsHot.hotStarter == 4)
        {
            transform.position = player4.transform.position;
        }
    }
}
