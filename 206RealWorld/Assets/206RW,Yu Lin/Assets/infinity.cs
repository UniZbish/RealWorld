using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infinity : MonoBehaviour
{
   public float  speed = -0.01f;
   private Vector2 offset;
   float nowpos;

   void Start(){
   
     offset = new Vector2 (0,0);

	 GetComponent<Renderer>().material.SetTextureOffset ("_MainTex", offset);

   }

   void Update(){
   
       nowpos += speed*Time.deltaTime;
	   offset = new Vector2 (nowpos, 0f);

	   GetComponent<Renderer>().material.SetTextureOffset ("_MainTex", offset);
   }

}