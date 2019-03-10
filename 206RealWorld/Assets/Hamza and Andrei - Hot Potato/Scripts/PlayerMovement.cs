using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    private float speed = 0.1f;
    public int playerNum;
    public bool hot;

    public KeyCode upward;
    public KeyCode downward;
    public KeyCode leftward;
    public KeyCode rightward;

    public PlayerMovement player1, player2, player3, player4;

    SpriteRenderer playerspriteproperties;
    RoundStart startingHot;
    PotatoTimer playerDeath;

    public void Start()
    {
        playerspriteproperties = GetComponent<SpriteRenderer>();
        playerDeath = GameObject.Find("countdownText").GetComponent<PotatoTimer>();
        startingHot = GameObject.Find("RoundStarter").GetComponent<RoundStart>();


        WhoIsHot();
    }

    void Update()
    {
        Move();

        if (hot == true)
        {
            playerspriteproperties.color = Color.red;
            BecomeHot();
        }
        else
        {
            playerspriteproperties.color = Color.white;
        }

    }

    private void Move()
    {
        if (Input.GetKey(upward) == true) transform.Translate(0f, speed, 0f);
        if (Input.GetKey(downward) == true) transform.Translate(0f, -speed, 0f);
        if (Input.GetKey(leftward) == true) transform.Translate(-speed, 0f, 0f);
        if (Input.GetKey(rightward) == true) transform.Translate(speed, 0f, 0f);
    }

    private void BecomeHot()
    {
        if (playerDeath.explosionCountdown < 1)
        {
            Debug.Log("Player " + startingHot.hotStarter.ToString() + " has been eliminated!");
            Destroy(GameObject.Find("Player " + startingHot.hotStarter.ToString()));
            startingHot.playerList.Remove(startingHot.hotStarter);
        }
    }

    private void WhoIsHot()
    {
        if (playerNum == 1 && startingHot.hotStarter == 1)
        {
            Debug.Log("Player 1 starts with the Hot Potato.");
        }
        if (playerNum == 2 && startingHot.hotStarter == 2)
        {
            Debug.Log("Player 2 starts with the Hot Potato.");
        }
        if (playerNum == 3 && startingHot.hotStarter == 3)
        {
            Debug.Log("Player 3 starts with the Hot Potato.");
        }
        if (playerNum == 4 && startingHot.hotStarter == 4)
        {
            Debug.Log("Player 4 starts with the Hot Potato.");
        }
    }

}
