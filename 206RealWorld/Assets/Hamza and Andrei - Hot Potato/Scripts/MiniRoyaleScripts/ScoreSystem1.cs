using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem1 : MonoBehaviour
{
    public Text scoreP1, scoreP2, scoreP3, scoreP4;
    public int player1Score, player2Score, player3Score, player4Score;

    // Start is called before the first frame update
    void Start()
    {
        //player1Score = player2Score = player3Score = player4Score = 0
    }

    // Update is called once per frame
    void Update()
    {
        scoreP1.text = player1Score.ToString();
        scoreP2.text = player2Score.ToString();
        scoreP3.text = player3Score.ToString();
        scoreP4.text = player4Score.ToString();
    }
}
