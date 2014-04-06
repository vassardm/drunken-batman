using UnityEngine;
using System.Collections;

public class GameBehavior : MonoBehaviour {

	public int highScoreCounter = 1000000;
	public int scoreCounter = 0;
	public int numOfLives = 99;
	public int bombCounter = 99;
	public int grazeMultiplier = 1;
	public int grazeCounter = 0;
	public int enemiesKilled = 0;
	public bool bossKilled;

	public bool paused = false;

	public float fireRate;
	public float firePower = 0;
	public float numOfBullets = 1;

	public UILabel scoreLabel;
	public UILabel highScoreLabel;
	public UILabel grazeLabel;

	public AudioClip backgroundLevelMusic;
	public AudioClip grazeClip;

	public GUIText placeholder;

	private float defaultFireRate = .4f;


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
		highScoreCounter = PlayerPrefs.GetInt("1HighScore");  // default is 0
		highScoreLabel.text = highScoreCounter.ToString();
		
		grazeLabel = GameObject.Find ("Graze Label").GetComponent < UILabel>();
		grazeLabel.text = "x" + grazeMultiplier.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Q))
        {
            Application.LoadLevel("AvastAlpha");
        }
	
		if (Input.GetKeyDown (KeyCode.P)) {
			if (Time.timeScale == 1){
				Time.timeScale = 0;
				paused = true;
				audio.volume = .1f;
			} else {
				Time.timeScale = 1;
				paused = false;
				audio.volume = .3f;
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
		int levelThreePowerBenchmark = 13;
		int levelFourPowerBenchmark = 19;
		int levelFivePowerBenchmark = 26;
		int levelSixPowerBenchmark = 32;


		if (firePower >= levelSixPowerBenchmark){
			float fireRateReductionBonus = (0.0025f * firePower);
			fireRate =  (defaultFireRate / 2.25f) - fireRateReductionBonus;
			numOfBullets = 3;
		}

		else if (firePower >= levelFivePowerBenchmark){
			float fireRateReductionBonus = (0.0020f * firePower);
			fireRate =  (defaultFireRate / 2.125f) - fireRateReductionBonus;
			numOfBullets = 2;
		}

		else if (firePower >= levelFourPowerBenchmark){
			float fireRateReductionBonus = (0.0016f * firePower);
			fireRate = (defaultFireRate / 2.0f) - fireRateReductionBonus;
			numOfBullets = 2;
		}

		else if (firePower >= levelThreePowerBenchmark){
			float fireRateReductionBonus = (0.0014f * firePower);
			fireRate = (defaultFireRate / 1.75f) - fireRateReductionBonus;
			numOfBullets = 2;
		}
		
		else if (firePower >= levelTwoPowerBenchmark){
			float fireRateReductionBonus = (0.0012f * firePower);
			fireRate = (defaultFireRate / 1.5f) - fireRateReductionBonus;
			numOfBullets = 2;
		}	
		
		else if (firePower >= levelOnePowerBenchmark){
			float fireRateReductionBonus = (0.0011f * firePower);
			fireRate = (defaultFireRate / 1.25f) - fireRateReductionBonus;
			numOfBullets = 1;
		}
		
		else if(firePower < levelOnePowerBenchmark){
			float fireRateReductionBonus = (0.010f * firePower);
			fireRate = defaultFireRate - fireRateReductionBonus;
			numOfBullets = 1;
		}
	}

	public void updateGraze(){
		int levelOneGrazeBenchmark = 4;
		int levelTwoGrazeBenchmark = 9;
		int levelThreeGrazeBenchmark = 15;
		float volume = 1f;

		//print ("in graze trigger");
		audio.PlayOneShot(grazeClip, volume);
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

	public void saveScore() {
		PlayerPrefs.SetInt ("savedScore", scoreCounter);

		// moved logic to gameover / victory scene
		/*int oldScore;
		int newScore = scoreCounter;

		string oldName;
		string newName = PlayerPrefs.GetString ("initials", "INI");

		for (int i = 1; i < 6; i++) {
			if (PlayerPrefs.GetInt (i + "HighScore") < newScore) {
				oldScore = PlayerPrefs.GetInt(i + "HighScore");
				oldName = PlayerPrefs.GetString (i + "Name");

				PlayerPrefs.SetInt(i + "HighScore", newScore);
				PlayerPrefs.SetString(i + "Name", newName);

				newScore = oldScore;
				newName = oldName;
			} 
		} */
	}
}
