using UnityEngine;
using System.Collections;

public class GameBehavior : MonoBehaviour {

	public int highScoreCounter = 1000;
	public int scoreCounter = 0;
	public int numOfLives = 3;
	public int bombCounter = 2;
	public float fireRate = .3f;
	public UILabel scoreLabel;
	public UILabel highScoreLabel;

	public GUIText text;

	// Use this for initialization
	void Start () {
		scoreCounter = 0;

		scoreLabel = GameObject.Find ("Current Score").GetComponent < UILabel>();
		scoreLabel.text = scoreCounter.ToString();

		highScoreLabel = GameObject.Find ("High Score").GetComponent < UILabel>();
		highScoreLabel.text = highScoreCounter.ToString();

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
		scoreLabel = GameObject.Find ("Current Score").GetComponent < UILabel>();
		scoreLabel.text = scoreCounter.ToString();
	

		if (scoreCounter >= highScoreCounter) {
			highScoreCounter = scoreCounter;
			highScoreLabel = GameObject.Find ("High Score").GetComponent < UILabel> ();
			highScoreLabel.text = scoreCounter.ToString ();
		}


	//	text.text = "Score: " + scoreCounter + "\nLives Left: " + numOfLives + "\nBombs Left: " + bombCounter;
	}
}
