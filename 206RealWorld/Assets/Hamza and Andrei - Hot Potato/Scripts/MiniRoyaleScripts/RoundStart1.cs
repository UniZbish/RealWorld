using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundStart1 : MonoBehaviour
{
    public int hotStarter;
    public List<int> playerList = new List<int>();
    public float timer;
    PotatoTimer roundRestart;
    PlayerMovement startNewRound1;
    PlayerMovement startNewRound2;
    PlayerMovement startNewRound3;
    PlayerMovement startNewRound4;
    // Start is called before the first frame update
    void Start()
    {
        timer = 5.5f;
      playerList.Add(1);
      playerList.Add(2);
      playerList.Add(3);
      playerList.Add(4);


      hotStarter = playerList[Random.Range(0, playerList.Count)];
      Debug.Log(hotStarter);
      roundRestart = GameObject.Find("countdownText").GetComponent<PotatoTimer>();

      if(GameObject.Find("Player 1") != null){
        startNewRound1 = GameObject.Find("Player 1").GetComponent<PlayerMovement>();
      }
      if(GameObject.Find("Player 2") != null){
        startNewRound2 = GameObject.Find("Player 2").GetComponent<PlayerMovement>();
      }
      if(GameObject.Find("Player 3") != null){
        startNewRound3 = GameObject.Find("Player 3").GetComponent<PlayerMovement>();
      }
      if(GameObject.Find("Player 4") != null){
        startNewRound4 = GameObject.Find("Player 4").GetComponent<PlayerMovement>();
      }

    }

    void restartRound()
    {
      roundRestart.explosionCountdown = timer;
      hotStarter = playerList[Random.Range(0, playerList.Count)];

      if(startNewRound1 != null){
        startNewRound1.Start();
      }
      if(startNewRound2 != null){
        startNewRound2.Start();
      }
      if(startNewRound3 != null){
        startNewRound3.Start();
      }
      if(startNewRound4 != null){
        startNewRound4.Start();
      }

    }
    // Update is called once per frame
    void Update()
    {
      if(roundRestart.explosionCountdown < 0.5f)
      {
        restartRound();
      }
    }

}
