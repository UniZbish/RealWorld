using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayersJoinLeave : MonoBehaviour
{
    public Image Lobby1, Lobby2, Lobby3, Lobby4;
    public Text readyText;
    public Button readyButton;
    public bool P1Act, P2Act, P3Act, P4Act, ready;
    public Sprite Cross, Tick;
    public int Lobby = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (P1Act == false)
            {
                Lobby1.sprite = Tick;
                P1Act = true;
                Lobby++;
            }
            else
            {
                Lobby1.sprite = Cross;
                P1Act = false;
                Lobby--;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (P2Act == false)
            {
                Lobby2.sprite = Tick;
                P2Act = true;
                Lobby++;
            }
            else
            {
                Lobby2.sprite = Cross;
                P2Act = false;
                Lobby--;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (P3Act == false)
            {
                Lobby3.sprite = Tick;
                P3Act = true;
                Lobby++;
            }
            else
            {
                Lobby3.sprite = Cross;
                P3Act = false;
                Lobby--;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (P4Act == false)
            {
                Lobby4.sprite = Tick;
                P4Act = true;
                Lobby++;
            }
            else
            {
                Lobby4.sprite = Cross;
                P4Act = false;
                Lobby--;
            }
        }

        if (Lobby == 4)
        {
            readyText.text = "READY!!!!";
            readyButton.interactable = true;
            readyButton.GetComponentInChildren<Text>().text = "Click to continue";
        }
        else
        {
            readyText.text = "LOBBY";
            readyButton.interactable = false;
            readyButton.GetComponentInChildren<Text>().text = "";
        }
    }
}
