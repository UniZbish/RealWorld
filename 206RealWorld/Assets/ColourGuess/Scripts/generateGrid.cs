using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class generateGrid : MonoBehaviour {
	public GameObject camera, red, yellow, green, blue, elimBtn, pointsBtn,cross,cross2,cross3;
	public Vector3 startPos, endPos;
	public int roundNum, currentTilesAmount, increment, maxRounds,currentRound,points, elimCount;
	public float incrementSize, timeLimit, timeLeft;
	public double redCount, blueCount, yellowCount, greenCount, totalTileCount,redCheck, blueCheck, greenCheck, yellowCheck;
	public System.Random rand = new System.Random();
	public List <GameObject> Winners = new List<GameObject> ();
	public List <GameObject> tiles = new List<GameObject> ();
	public List <GameObject> available = new List <GameObject>();
	public Image disk,yellowButton,blueButton,redButton,greenButton;
	public Sprite yellowButtonSprite, yellowButtonPressedSprite,blueButtonSprite,blueButtonPressedSprite,greenButtonSprite,greenButtonPressedSprite,redButtonSprite,redButtonPressedSprite;
	public Text Timertext,pointsText;
	bool colChosen = false;
	bool coolingDown = false;
    bool btnPressed = false;
    bool gameOver = false;
	string mode;
	// Use this for initialization
	void Start () {
		currentTilesAmount = currentTilesAmount-increment;
		anchorCamera ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		pointsText.text = "Points: " + points;
		if (Input.GetButtonDown("YButton")) {
			pressButton (yellowButton, yellowButtonSprite, yellowButtonPressedSprite, yellow);
		}
		if (Input.GetButtonDown("XButton")) {
			pressButton (blueButton, blueButtonSprite, blueButtonPressedSprite, blue);
		}
		if (Input.GetButtonDown("BButton")) {
			pressButton (redButton, redButtonSprite, redButtonPressedSprite, red);
		}
		if (Input.GetButtonDown("AButton")) {
			pressButton (greenButton, greenButtonSprite, greenButtonPressedSprite, green);
		}

		if (coolingDown == true) {
			//Reduce fill amount over 30 seconds
			disk.fillAmount -= 1.0f / timeLimit * Time.deltaTime;
			timeLeft -= Time.deltaTime;
			Timertext.text = "" + Mathf.Ceil (timeLeft);
			if (disk.fillAmount == 0) {
				coolingDown = false;
			}
		}
	}
	void pressButton(Image button, Sprite buttonSprite, Sprite PressedSprite, GameObject colour){
        if (!gameOver)
        {
            btnPressed = true;
            bool correct = false;
            if (!colChosen)
            {
                foreach (GameObject col in Winners)
                {
                    if (col == colour)
                    {
                        points++;
                        correct = true;
                    }
                }
                if (mode == "elimination" && !correct)
                {
                    print("life lost");
                    elimCount++;
                }
                colChosen = true;
            }
        }
	}

	IEnumerator timeLimitWaiter(){
		yield return new WaitForSeconds (timeLimit);
        if (!btnPressed && mode == "elimination")
        {
            elimCount++;
        }
        if(mode == "easy")
        {
            if (currentRound < maxRounds)
            {
                startRound();
            } else
            {
                gameOver = true;
            }
        }
        else if (mode == "elimination")
        {
            if (elimCount < 3)
            {
                startRound();
            }
            else
            {
                gameOver = true;
            }
    }
	}

	void generateNewGridEasy(){
		//Increments the length and width of grid by the increment value
		currentRound++;
		disk.fillAmount = 1;
		colChosen = false;
		timeLeft = timeLimit;
		coolingDown = true;
		redCount = blueCount = greenCount = yellowCount = 0;
		currentTilesAmount = currentTilesAmount + increment;
		//Calculates the distance between spawn points of each tile
		endPos = new Vector3(startPos.x+(currentTilesAmount*blue.GetComponentInChildren<Renderer>().bounds.size.x),startPos.y+(currentTilesAmount*blue.GetComponentInChildren<Renderer>().bounds.size.x));
		incrementSize = ((endPos.x - startPos.x) / (currentTilesAmount));
		endPos = new Vector3 (endPos.x - incrementSize, endPos.y - incrementSize);
		while (camera.transform.position.y < (currentTilesAmount * blue.GetComponentInChildren<Renderer> ().bounds.size.x) / 2) {
			Camera.main.orthographicSize = Camera.main.orthographicSize + 0.01f;
			anchorCamera ();
		}
		//Draws the grid
		float x, y;
		for (x = 0; x < currentTilesAmount; x++) {
			for (y = 0; y < currentTilesAmount; y++) {
				GameObject newTile = Instantiate (chooseColourEasy());
				tiles.Add (newTile);
				newTile.transform.position = new Vector3 ((startPos.x + incrementSize) * x, (startPos.y + incrementSize) * y,0);
			}
		}
		double currentMax = redCount;
		Winners.Clear ();
		Winners.Add (red);
		if (greenCount > currentMax) {
			Winners.Clear ();
			Winners.Add (green);
			currentMax = greenCount;
		} else if (greenCount == currentMax) {
			Winners.Add (green);
		}
		if (blueCount > currentMax) {
			Winners.Clear ();
			Winners.Add (blue);
			currentMax = blueCount;
		} else if (blueCount == currentMax) {
			Winners.Add (blue);
		}
		if (yellowCount > currentMax) {
			Winners.Clear ();
			Winners.Add (yellow);
			currentMax = yellowCount;
		} else if (yellowCount == currentMax) {
			Winners.Add (yellow);
		}
	}

	void anchorCamera(){
		float aspectRatio = Camera.main.aspect;
		float camSize = Camera.main.orthographicSize;
		float correctPositionX = aspectRatio * camSize;
		Camera.main.transform.position = new Vector3 (correctPositionX, camSize, -1);
	}
	GameObject chooseColourEasy(){
		int index = rand.Next (0, 4);
		switch (index) {
		case 0:
			redCount++;
			return red;
		case 1:
			blueCount++;
			return blue;
		case 2:
			greenCount++;
			return green;
		case 3:
			yellowCount++;
			return yellow;
		default:
			break;
		}
		return (null);
	}

	void clearGrid(){
		foreach (GameObject tile in tiles) {
			Destroy (tile);
		}
		tiles.Clear();
	}

    public void startEasy()
    {
        currentRound = 0;
        points = 0;
        mode = "easy";
        elimBtn.SetActive(false);
        pointsBtn.SetActive(false);
        startRound();
    }

    public void startElimination()
    {
        currentRound = 0;
        points = 0;
        mode = "elimination";
        elimBtn.SetActive(false);
        pointsBtn.SetActive(false);
        startRound();
    }

	void startRound(){
        btnPressed = false;
        clearGrid ();
		generateNewGridEasy ();
		StartCoroutine(timeLimitWaiter ());
	}
}