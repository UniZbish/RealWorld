using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotatoTimer : MonoBehaviour
{
  public float explosionCountdown;
  public Text countText;
    RoundStart start;
    // Start is called before the first frame update
    void Start()
    {

      explosionCountdown = start.timer;
    }

    // Update is called once per frame
    void Update()
    {
      explosionCountdown -= Time.deltaTime;
      countText.text =  explosionCountdown.ToString("f0");
    }
}
