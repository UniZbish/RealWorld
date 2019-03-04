using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    private float speed = 0.1f;
    public int playerNum;
    public bool hot;
    int players;

    public KeyCode upward;
    public KeyCode downward;
    public KeyCode leftward;
    public KeyCode rightward;

    public PlayerMovement player1, player2, player3, player4;

    SpriteRenderer playerspriteproperties;
    RoundStart startingHot;
    PotatoTimer playerDeath;
    public ScoreSystem score;

    public void Start()
    {
        playerspriteproperties = GetComponent<SpriteRenderer>();
        playerDeath = GameObject.Find("countdownText").GetComponent<PotatoTimer>();
        startingHot = GameObject.Find("RoundStarter").GetComponent<RoundStart>();
    }

    void Update()
    {
        Move();

        if (hot == true){
            playerspriteproperties.color = Color.red;
            Die();
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

    private void Die()
    {
        if (playerDeath.explosionCountdown < 1)
        {
            if(startingHot.hotStarter == 1)
            {
                if (startingHot.playerList.Count == 4) score.player1Score += 1;
                else if (startingHot.playerList.Count == 3) score.player1Score += 2;
                else if (startingHot.playerList.Count == 2) score.player1Score += 3;
                else if (startingHot.playerList.Count == 1) score.player1Score += 5;
            }
            else if (startingHot.hotStarter == 2)
            {
                 if (startingHot.playerList.Count == 4) score.player2Score += 1;
                else if (startingHot.playerList.Count == 3) score.player2Score += 2;
                else if(startingHot.playerList.Count == 2) score.player2Score += 3;
                else if (startingHot.playerList.Count == 1) score.player2Score += 5;
            }
            else if (startingHot.hotStarter == 3)
            {
                 if(startingHot.playerList.Count == 4) score.player3Score += 1;
                else if(startingHot.playerList.Count == 3) score.player3Score += 2;
                else if(startingHot.playerList.Count == 2) score.player3Score += 3;
                else if(startingHot.playerList.Count == 1) score.player3Score += 5;
            }
            else if (startingHot.hotStarter == 4)
            {
                 if(startingHot.playerList.Count == 4) score.player4Score += 1;
                else if(startingHot.playerList.Count == 3) score.player4Score += 2;
                else if(startingHot.playerList.Count == 2) score.player4Score += 3;
                else if(startingHot.playerList.Count == 1) score.player4Score += 5;
            }

            Debug.Log("Player " + startingHot.hotStarter.ToString() + " has been eliminated!   and " + startingHot.playerList.Count.ToString() + " left");
            Destroy(GameObject.Find("Player " + startingHot.hotStarter.ToString()));
            startingHot.playerList.Remove(startingHot.hotStarter);
            
        }
    }
}
