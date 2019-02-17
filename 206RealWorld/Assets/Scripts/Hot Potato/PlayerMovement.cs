using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public string upward;
  public string downward;
  public string leftward;
  public string rightward;
  public int playerNum;
  public bool hot;
  SpriteRenderer playerspriteproperties;
  RoundStart startingHot;
  PotatoTimer playerDeath;
    // Start is called before the first frame update
    public void Start()
    {
      playerspriteproperties = GetComponent<SpriteRenderer>();
      playerDeath = GameObject.Find("countdownText").GetComponent<PotatoTimer>();
      startingHot = GameObject.Find("RoundStarter").GetComponent<RoundStart>();
      if (playerNum==1){
        upward = "up";
        downward = "down";
        leftward = "left";
        rightward = "right";
        if(startingHot.hotStarter == 1){
          hot = true;
          Debug.Log("Player 1 starts with the Hot Potato.");
        }
      }
      if (playerNum==2){
        upward = "w";
        downward = "s";
        leftward = "a";
        rightward = "d";
        if(startingHot.hotStarter == 2){
          hot = true;
          Debug.Log("Player 2 starts with the Hot Potato.");
        }
      }
      if (playerNum==3){
        upward = "t";
        downward = "g";
        leftward = "f";
        rightward = "h";
        if(startingHot.hotStarter == 3){
          hot = true;
          Debug.Log("Player 3 starts with the Hot Potato.");
        }
      }
      if (playerNum==4){
        upward = "i";
        downward = "k";
        leftward = "j";
        rightward = "l";
        if(startingHot.hotStarter == 4){
          hot = true;
          Debug.Log("Player 4 starts with the Hot Potato.");
        }
      }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(upward) == true){
          gameObject.transform.Translate(new Vector2 (0, 1) * 8 * Time.deltaTime);
        }
        if (Input.GetKey(downward) == true){
          gameObject.transform.Translate(new Vector2 (0, -1) * 8 * Time.deltaTime);
        }
        if (Input.GetKey(leftward) == true){
          gameObject.transform.Translate(new Vector2 (-1, 0) * 8 * Time.deltaTime);
        }
        if (Input.GetKey(rightward) == true){
          gameObject.transform.Translate(new Vector2 (1, 0) * 8 * Time.deltaTime);
        }
        if (hot == true){
          playerspriteproperties.color = Color.red;
          if (playerDeath.explosionCountdown < 1.0f){
            Debug.Log("Player " + startingHot.hotStarter.ToString() + " has been eliminated!");
            Destroy(GameObject.Find("Player " + startingHot.hotStarter.ToString()));
            startingHot.playerList.Remove(startingHot.hotStarter);
          }
        }

    }
}
