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

        if (hot == true){
            BecomeHot();
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
        playerspriteproperties.color = Color.red;
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
            player1.hot = true;
            player2.hot = false;
            player3.hot = false;
            player4.hot = false;
            Debug.Log("Player 1 starts with the Hot Potato.");
        }
        if (playerNum == 2 && startingHot.hotStarter == 2)
        {
            player1.hot = false;
            player2.hot = true;
            player3.hot = false;
            player4.hot = false;
            Debug.Log("Player 2 starts with the Hot Potato.");
        }
        if (playerNum == 3 && startingHot.hotStarter == 3)
        {
            player1.hot = false;
            player2.hot = false;
            player3.hot = true;
            player4.hot = false;
            Debug.Log("Player 3 starts with the Hot Potato.");
        }
        if (playerNum == 4 && startingHot.hotStarter == 4)
        {
            player1.hot = false;
            player2.hot = false;
            player3.hot = false;
            player4.hot = true;
            Debug.Log("Player 4 starts with the Hot Potato.");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player1" && !player1.hot)
        {
            startingHot.hotStarter = 1;
            player1.hot = true;
            player2.hot = false;
            player3.hot = false;
            player4.hot = false;
        }
        if (collision.gameObject.tag == "Player2" && !player2.hot)
        {
            startingHot.hotStarter = 2;
            player1.hot = false;
            player2.hot = true;
            player3.hot = false;
            player4.hot = false;
        }
        if (collision.gameObject.tag == "Player3" && !player3.hot)
        {
            startingHot.hotStarter = 3;
            player1.hot = false;
            player2.hot = false;
            player3.hot = true;
            player4.hot = false;
        }
        if (collision.gameObject.tag == "Player4" && !player4.hot)
        {
            startingHot.hotStarter = 4;
            player1.hot = false;
            player2.hot = false;
            player3.hot = false;
            player4.hot = true;
        }
    }
}
