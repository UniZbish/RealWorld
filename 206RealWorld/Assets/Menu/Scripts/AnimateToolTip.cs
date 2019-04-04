using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimateToolTip : MonoBehaviour {

	public float speed = 5;
	public GameObject text;
	public Image self;

	// Use this for initialization
	void Start () {
		self = GetComponent<Image> ();
		StartCoroutine(AnimateTileIn());
	}

	// Update is called once per frame
	void Update () {

	}
	IEnumerator AnimateTileIn(){
		self.fillAmount = 0;
		float timer = 0f;
		while (timer < (1/speed)){
			timer += Time.deltaTime;
			self.fillAmount = 1 * timer * speed;
			yield return null;
		}
		self.fillAmount = 1;
		text.SetActive (true);
		StartCoroutine (WaitSeconds());
	}

	IEnumerator WaitSeconds(){
		yield return new WaitForSeconds (1.5f);
		StartCoroutine (AnimateTileOut());
	}

	IEnumerator AnimateTileOut(){
		text.SetActive (false);
		float timer = 0f;
		while (timer < (1/speed)){
			timer += Time.deltaTime;
			self.fillAmount -= 1 * timer / speed;
			/*
			if (self.fillAmount <=0) {
				break;
			}
			*/
			yield return null;
		}
		self.fillAmount = 0;
		Destroy (this.gameObject);
	}
}
