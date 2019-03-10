using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotPotato : MonoBehaviour
{

    public GameObject player1, player2, player3, player4;
    public PlayerMovement P1, P2, P3, P4;


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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player1" && !P1.hot)
        {
            whoIsHot.hotStarter = 1;
            P1.hot = true;
            P2.hot = false;
            P3.hot = false;
            P4.hot = false;
            StartCoroutine(TriggerHider());
        }
        if (collision.gameObject.tag == "Player2" && !P2.hot)
        {
            whoIsHot.hotStarter = 2;
            P1.hot = false;
            P2.hot = true;
            P3.hot = false;
            P4.hot = false;
            StartCoroutine(TriggerHider());
        }
        if (collision.gameObject.tag == "Player3" && !P3.hot)
        {
            whoIsHot.hotStarter = 3;
            P1.hot = false;
            P2.hot = false;
            P3.hot = true;
            P4.hot = false;
            StartCoroutine(TriggerHider());
        }
        if (collision.gameObject.tag == "Player4" && !P4.hot)
        {
            whoIsHot.hotStarter = 4;
            P1.hot = false;
            P2.hot = false;
            P3.hot = false;
            P4.hot = true;
            StartCoroutine(TriggerHider());
        }
    }

    IEnumerator TriggerHider()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(1);
        GetComponent<BoxCollider2D>().enabled = true;
    }
}
