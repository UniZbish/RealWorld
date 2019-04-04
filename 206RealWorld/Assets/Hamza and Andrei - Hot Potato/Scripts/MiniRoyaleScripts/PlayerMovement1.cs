using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    
    private float speed = 0.1f;
    public int playerNum;
    public bool hasGun;

    public KeyCode upward;
    public KeyCode downward;
    public KeyCode leftward;
    public KeyCode rightward;

    public PlayerMovement player1, player2, player3, player4;
    public GameObject gun;

    SpriteRenderer playerspriteproperties;
    RoundStart startingHot;
    PotatoTimer playerDeath;
    ScoreSystem score;

    public void Start()
    {
        score = GameObject.Find("ScoreSystem").GetComponent<ScoreSystem>();

    }

    void Update()
    {
        Move();
        if (hasGun)
        {

        }
    }

    private void Move()
    {
        if (Input.GetKey(upward) == true) transform.Translate(0f, speed, 0f);
        if (Input.GetKey(downward) == true) transform.Translate(0f, -speed, 0f);
        if (Input.GetKey(leftward) == true) transform.Translate(-speed, 0f, 0f);
        if (Input.GetKey(rightward) == true) transform.Translate(speed, 0f, 0f);
    }



}
