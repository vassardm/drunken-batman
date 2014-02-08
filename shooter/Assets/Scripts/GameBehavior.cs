using UnityEngine;
using System.Collections;

public class GameBehavior : MonoBehaviour {

	public int highScoreCounter = 5;
	public int scoreCounter = 0;
	public int numOfLives = 4;
	public int bombCounter = 4;
	private float defaultFireRate = .3f;
	public float fireRate;
	public float firePower = 0;
	public float numOfBullets = 1;
	public int grazeMultiplier = 1;
	public int grazeCounter = 0;
	public UILabel scoreLabel;
	public UILabel highScoreLabel;
	public UILabel grazeLabel;
	public AudioClip backgroundLevelMusic;


	public GUIText text;

	// Use this for initialization
	void Start () {
		scoreCounter = 0;
		grazeMultiplier = 1;
		grazeCounter = 0;
		audio.Play ();

		scoreLabel = GameObject.Find ("Current Score").GetComponent < UILabel>();
		scoreLabel.text = scoreCounter.ToString();

		highScoreLabel = GameObject.Find ("High Score").GetComponent < UILabel>();
		highScoreLabel.text = highScoreCounter.ToString();

		grazeLabel = GameObject.Find ("Graze Label").GetComponent < UILabel>();
		grazeLabel.text = "x" + grazeMultiplier.ToString();

		fireRate = defaultFireRate;
		scoreCounter = 0;
		firePower = 0;
		text.text = "";
		fireRate = defaultFireRate;
		scoreCounter = 0;
		firePower = 0;
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

		if (grazeCounter < 15) {
			grazeLabel.text = "x" + grazeMultiplier.ToString();
		}

		if (grazeCounter >= 15 && grazeCounter <= 31) {
			grazeLabel.text = "x" + grazeMultiplier.ToString();
		}

		if (grazeCounter >= 31 && grazeCounter <= 63) {
			grazeLabel.text = "x" + grazeMultiplier.ToString();
		}

		if (grazeCounter > 63) {
			grazeLabel.text = "x" + grazeMultiplier.ToString();
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

	public void increaseFireRate(){
		firePower++;
		if(firePower > 15 && firePower <= 31){
			fireRate = defaultFireRate/2;
		}
		if(firePower > 31 && fireRate <= 63){
			fireRate = defaultFireRate;
			numOfBullets = 2;
		}
		if(firePower > 63){
			fireRate = defaultFireRate/2;
			numOfBullets = 2;
		}
	}
}
