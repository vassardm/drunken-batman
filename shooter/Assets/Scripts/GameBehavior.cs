﻿using UnityEngine;
using System.Collections;

public class GameBehavior : MonoBehaviour {

	public int highScoreCounter = 1000;
	public int scoreCounter = 0;
	public int numOfLives = 3;
	public int bombCounter = 3;
	public int grazeMultiplier = 1;
	public int grazeCounter = 0;
	public int enemiesKilled;
	public bool bossKilled;

	public bool paused = false;

	public float fireRate;
	public float firePower = 0;
	public float numOfBullets = 1;

	public UILabel scoreLabel;
	public UILabel highScoreLabel;
	public UILabel grazeLabel;

	public AudioClip backgroundLevelMusic;

	public GUIText placeholder;

	private float defaultFireRate = .3f;


	// Use this for initialization
	void Start () {
		launchDefaultCounters ();
		launchAudio ();
		launchLabels ();
	}

	public void launchDefaultCounters() {
		scoreCounter = 0;
		grazeCounter = 0;
		firePower = 0;
		enemiesKilled = 0;
		fireRate = defaultFireRate;
		grazeMultiplier = 1;
	}

	public void launchAudio() {
		audio.Play ();
	}

	public void launchLabels() {
		scoreLabel = GameObject.Find ("Current Score").GetComponent < UILabel>();
		scoreLabel.text = scoreCounter.ToString();
		
		highScoreLabel = GameObject.Find ("High Score").GetComponent < UILabel>();
		highScoreLabel.text = highScoreCounter.ToString();
		
		grazeLabel = GameObject.Find ("Graze Label").GetComponent < UILabel>();
		grazeLabel.text = "x" + grazeMultiplier.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (KeyCode.P)) {
			if (Time.timeScale == 1){
				Time.timeScale = 0;
				paused = true;
				//audio.Pause ();
			} else {
				Time.timeScale = 1;
				paused = false;
				//audio.Play();
			}
		}

		updateGrazeMeterFunctionality ();
		updateScoreandHighScoreFunctionality ();
		updateFirePower ();

	}

	public void updateScoreandHighScoreFunctionality() {
		scoreLabel = GameObject.Find ("Current Score").GetComponent < UILabel>();
		scoreLabel.text = scoreCounter.ToString();
		
		
		if (scoreCounter >= highScoreCounter) {
			highScoreCounter = scoreCounter;
			highScoreLabel = GameObject.Find ("High Score").GetComponent < UILabel> ();
			highScoreLabel.text = scoreCounter.ToString ();
		}	
	}

	public void updateGrazeMeterFunctionality() {
		string multiplerSymbol = "x";
		int levelOneGrazeBenchmark = 15;
		int levelTwoGrazeBenchmark = 31;
		int levelThreeGrazeBenchmark = 63;

		// Ensures Score Updates are multiplied by 1
		if (grazeCounter < levelOneGrazeBenchmark) {
			grazeLabel.text = multiplerSymbol + grazeMultiplier.ToString();
		}

		// Ensures Score Updates are multiplied by 2
		if (grazeCounter > levelOneGrazeBenchmark && grazeCounter <= levelTwoGrazeBenchmark) {
			grazeLabel.text = multiplerSymbol + grazeMultiplier.ToString();
		}

		// Ensures Score Updates are multiplied by 4
		if (grazeCounter > levelTwoGrazeBenchmark && grazeCounter <= levelThreeGrazeBenchmark) {
			grazeLabel.text = multiplerSymbol + grazeMultiplier.ToString();
		}

		// Ensures Score Updates are multiplied by 8
		if (grazeCounter > levelThreeGrazeBenchmark) {
			grazeLabel.text = multiplerSymbol + grazeMultiplier.ToString();
		}
	}

	public void increaseFireRate(){
		firePower++;
		updateFirePower ();

	}

	public void updateFirePower(){

		int levelOnePowerBenchmark = 4;
		int levelTwoPowerBenchmark = 8;
		int levelThreePowerBenchmark = 16;
		
		if (firePower >= levelThreePowerBenchmark){
			fireRate = defaultFireRate / 2;
			numOfBullets = 2;
		}
		
		else if (firePower >= levelTwoPowerBenchmark){
			fireRate = defaultFireRate;
			numOfBullets = 2;
		}
		
		
		else if (firePower >= levelOnePowerBenchmark){
			fireRate = defaultFireRate / 2;
		}
		
		else if(firePower < levelOnePowerBenchmark){
			fireRate = defaultFireRate;
			numOfBullets = 1;
		}
	}

	public void updateGraze(){
		int levelOneGrazeBenchmark = 4;
		int levelTwoGrazeBenchmark = 9;
		int levelThreeGrazeBenchmark = 15;

		//print ("in graze trigger");
		grazeCounter++;
		if (grazeCounter > levelOneGrazeBenchmark && grazeCounter <= levelTwoGrazeBenchmark) {
			print ("graze level = 2");
			grazeMultiplier = 2;
		}
		if (grazeCounter > levelTwoGrazeBenchmark && grazeCounter <= levelThreeGrazeBenchmark) {
			print ("graze level = 4");
			grazeMultiplier = 4;
		}
		if (grazeCounter > levelThreeGrazeBenchmark){
			print ("graze level = 8");
			grazeMultiplier = 8;
		}
	}
}
