using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuGenerator : MonoBehaviour {

	public Canvas canvas;
	public Image preview;
	public Sprite noPreview;
	public Sprite buttonNormal;
	public Sprite buttonSelected;
	public GameObject scroller;
	public GameObject button;
	RectTransform rt;
	public float buttonHeight;
	public float buttonWidth;
	Vector3[] v;
	public int menuPos;
	public GameObject persistentController;
    bool dPadReleased = false;

    [System.Serializable]
	public class Option
	{
		public string name;
		public string sceneName;
		public Sprite image;
		public GameObject button;
	}

	public Option[] menu;

	// Use this for initialization
	void Start () {
		persistentController = GameObject.Find ("PersistentController");
		rt = canvas.GetComponent<RectTransform> ();
		v = new Vector3[4];
		rt.GetWorldCorners (v);
		int i = 0;
		foreach (Option option in menu) {
			GameObject newButton = Instantiate (button);
			menu [i].button = newButton;
			newButton.transform.position = new Vector2 (v[1].x,v[1].y);
			newButton.transform.localScale = new Vector3 (1, 1, 1);
			Vector2 spawnPosition = newButton.transform.position;
			newButton.transform.SetParent (scroller.transform);
			RectTransform buttonRT = newButton.GetComponentInChildren<RectTransform> ();
			buttonHeight = buttonRT.rect.height;
			buttonWidth = buttonRT.rect.width;
			newButton.transform.position = new Vector2 (transform.position.x, spawnPosition.y - (buttonRT.rect.height * i));
			newButton.GetComponentInChildren<Text> ().text = menu [i].name;
			newButton.GetComponentInChildren<LoadScene> ().sceneName = menu [i].sceneName;
			i++;
		}
		menu [menuPos].button.GetComponentInChildren<Image> ().sprite = buttonSelected;
		preview.sprite = menu [menuPos].image;
	}
	
	// Update is called once per frame
	void Update () {
        float dPadVert = Input.GetAxis("DPadVert");
		if (menu [menuPos].image != null) {
			preview.sprite = menu [menuPos].image;
		} else {
			preview.sprite = noPreview;
		}
        if(dPadVert < 0.5 && dPadVert > -0.5)
        {
            dPadReleased = true;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && menuPos < menu.Length - 1)
        {
            menuPos++;
            scroller.transform.position = new Vector2(v[1].x, v[1].y + (buttonHeight * menuPos));
            int i = 0;
            foreach (Option option in menu)
            {
                if (i == menuPos)
                {
                    option.button.GetComponentInChildren<Image>().sprite = buttonSelected;
                }
                else
                {
                    option.button.GetComponentInChildren<Image>().sprite = buttonNormal;
                }
                i++;
                //menu [menuPos].button.GetComponentInChildren<Image> ().color = Color.blue;
            }
        }
        else if (dPadVert < -0.5f && menuPos < menu.Length - 1 && dPadReleased)
        {
            dPadReleased = false;
            menuPos++;
            scroller.transform.position = new Vector2(v[1].x, v[1].y + (buttonHeight * menuPos));
            int i = 0;
            foreach (Option option in menu)
            {
                if (i == menuPos)
                {
                    option.button.GetComponentInChildren<Image>().sprite = buttonSelected;
                }
                else
                {
                    option.button.GetComponentInChildren<Image>().sprite = buttonNormal;
                }
                i++;
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && menuPos > 0)
        {
            dPadReleased = false;
            menuPos--;
            scroller.transform.position = new Vector2(v[1].x, v[1].y + (buttonHeight * menuPos));
            int i = 0;
            foreach (Option option in menu)
            {
                if (i == menuPos)
                {
                    option.button.GetComponentInChildren<Image>().sprite = buttonSelected;
                }
                else
                {
                    option.button.GetComponentInChildren<Image>().sprite = buttonNormal;
                }
                i++;
            }
        }
        else if (dPadVert > 0.5f && menuPos > 0 && dPadReleased)
        {
            dPadReleased = false;
            menuPos--;
            scroller.transform.position = new Vector2(v[1].x, v[1].y + (buttonHeight * menuPos));
            int i = 0;
            foreach (Option option in menu)
            {
                if (i == menuPos)
                {
                    option.button.GetComponentInChildren<Image>().sprite = buttonSelected;
                }
                else
                {
                    option.button.GetComponentInChildren<Image>().sprite = buttonNormal;
                }
                i++;
            }
        }
        else if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            persistentController.GetComponent<ToolTips>().needed = true;
            SceneManager.LoadScene(menu[menuPos].sceneName);
        } else if (Input.GetButtonDown("AButton"))
        {
            persistentController.GetComponent<ToolTips>().needed = true;
            SceneManager.LoadScene(menu[menuPos].sceneName);
        }
		/*
		//360 controller A button
		if (Input.GetButtonDown ("Fire1")) {
			SceneManager.LoadScene (menu[menuPos].sceneName);
		}
		*/
	}
}
