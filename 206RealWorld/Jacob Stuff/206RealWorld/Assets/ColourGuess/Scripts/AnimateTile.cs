using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateTile : MonoBehaviour {

	public float speed = 5;

	// Use this for initialization
	void Start () {
		StartCoroutine(AnimateTileIn());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	IEnumerator AnimateTileIn(){
		transform.localScale = Vector3.zero;
		float timer = 0f;
		while (timer < (1/speed)){
			timer += Time.deltaTime;
			transform.localScale = Vector3.one * timer * speed;
			yield return null;
		}
		transform.localScale = Vector3.one;
	}
}
