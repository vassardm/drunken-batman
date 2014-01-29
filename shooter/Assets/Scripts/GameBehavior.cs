using UnityEngine;
using System.Collections;

public class GameBehavior : MonoBehaviour {

	public int scoreCounter = 0;
	public int numOfLives = 4;
	public int bombCounter = 4;

	public GUIText text;

	// Use this for initialization
	void Start () {

		text.text = "";
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.P)) {
			if (Time.timeScale == 1){
				Time.timeScale = 0;
			} else {
				Time.timeScale = 1;
			}
		}

		text.text = "Score: " + scoreCounter + "\nLives Left: " + numOfLives + "\nBombs Left: " + bombCounter;
	}
}
