using UnityEngine;
using System.Collections;

public class GameBehavior : MonoBehaviour {

	public int highScoreCounter = 1000;
	public int scoreCounter = 0;
	public int numOfLives = 3;
	public int bombCounter = 3;
	public int grazeMultiplier = 1;
	public int grazeCounter = 0;

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
				audio.Pause ();
			} else {
				Time.timeScale = 1;
				audio.Play();
			}
		}

		updateGrazeMeterFunctionality ();
		updateScoreandHighScoreFunctionality ();

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
		int levelOnePowerBenchmark = 15;
		int levelTwoPowerBenchmark = 31;
		int levelThreePowerBenchmark = 63;

		firePower++;

		if (firePower > levelOnePowerBenchmark && firePower <= levelTwoPowerBenchmark){
			fireRate = defaultFireRate / 2;
		}

		if (firePower > levelTwoPowerBenchmark && fireRate <= levelThreePowerBenchmark){
			fireRate = defaultFireRate;
			numOfBullets = 2;
		}

		if (firePower > levelThreePowerBenchmark){
			fireRate = defaultFireRate / 2;
			numOfBullets = 2;
		}

	}
}
