using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToolTips : MonoBehaviour {

	public GameObject toolTip;
	RectTransform rt;
	public GameObject canvas;
	public bool needed = true;
	Vector3[] v;

	void Awake(){
		Object.DontDestroyOnLoad (this.gameObject);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyUp (KeyCode.Escape)) {
			SceneManager.LoadScene ("Main");
			Destroy (this.gameObject);
		} else if (Input.GetButtonDown("Back"))
        {
            SceneManager.LoadScene("Main");
            Destroy(this.gameObject);
        }
		if (needed) {
			canvas = GameObject.Find ("Canvas");
			rt = canvas.GetComponent<RectTransform> ();
			v = new Vector3[4];
			rt.GetWorldCorners (v);
			Scene scene = SceneManager.GetActiveScene ();
			if (scene.name != "Main") {
				GameObject newToolTip = Instantiate (toolTip);
				newToolTip.transform.SetParent (canvas.transform);
				newToolTip.transform.localScale = new Vector2 (0.75f, 0.75f);
				RectTransform rt = newToolTip.GetComponent<RectTransform> ();
				newToolTip.transform.position = new Vector2 (v [1].x, v [1].y);
				needed = false;
			}
		}
	}
}

