using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotPotato : MonoBehaviour
{

    public PlayerMovement Player1, Player2, Player3, Player4;
    public GameObject player1, player2, player3, player4;
    public BoxCollider2D potato;
    PotatoTimer playerDeath;


    RoundStart whoIsHot;


    // Start is called before the first frame update
    void Start()
    {
        whoIsHot = GameObject.Find("RoundStarter").GetComponent<RoundStart>();
        potato = GameObject.Find("Potato").GetComponent<BoxCollider2D>();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player1" && !Player1.hot)
        {
            whoIsHot.hotStarter = 1;
            Player1.hot = true;
            Player2.hot = false;
            Player3.hot = false;
            Player4.hot = false;
            StartCoroutine(Example());
            Debug.Log("Player 1 has the potato");
        }
        if (collision.gameObject.tag == "Player2" && !Player2.hot)
        {
            whoIsHot.hotStarter = 2;
            Player1.hot = false;
            Player2.hot = true;
            Player3.hot = false;
            Player4.hot = false;
            StartCoroutine(Example());
            Debug.Log("Player 2 has the potato");
        }
        if (collision.gameObject.tag == "Player3" && !Player3.hot)
        {
            whoIsHot.hotStarter = 3;
            Player1.hot = false;
            Player2.hot = false;
            Player3.hot = true;
            Player4.hot = false;
            StartCoroutine(Example());
            Debug.Log("Player 3 has the potato");
        }
        if (collision.gameObject.tag == "Player4" && !Player4.hot)
        {
            whoIsHot.hotStarter = 4;
            Player1.hot = false;
            Player2.hot = false;
            Player3.hot = false;
            Player4.hot = true;
            StartCoroutine(Example());
            Debug.Log("Player 4 has the potato");
        }
    }

    IEnumerator Example()
    {
        potato.enabled = false;
        yield return new WaitForSeconds(1);
        potato.enabled = true;
    }

}
