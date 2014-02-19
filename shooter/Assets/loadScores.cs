using UnityEngine;
using System.Collections;

public class loadScores : MonoBehaviour {

	public UILabel scoreLabel1;
	public UILabel scoreLabel2;
	public UILabel scoreLabel3;
	public UILabel scoreLabel4;
	public UILabel scoreLabel5;

	public UILabel nameLabel1;
	public UILabel nameLabel2;
	public UILabel nameLabel3;
	public UILabel nameLabel4;
	public UILabel nameLabel5;


	// Use this for initialization
	void Start () {
	
		scoreLabel1 = GameObject.Find ("Score1").GetComponent < UILabel>();
		scoreLabel2 = GameObject.Find ("Score2").GetComponent < UILabel>();
		scoreLabel3 = GameObject.Find ("Score3").GetComponent < UILabel>();
		scoreLabel4 = GameObject.Find ("Score4").GetComponent < UILabel>();
		scoreLabel5 = GameObject.Find ("Score5").GetComponent < UILabel>();

		nameLabel1 = GameObject.Find ("Name1").GetComponent < UILabel>();
		nameLabel2 = GameObject.Find ("Name2").GetComponent < UILabel>();
		nameLabel3 = GameObject.Find ("Name3").GetComponent < UILabel>();
		nameLabel4 = GameObject.Find ("Name4").GetComponent < UILabel>();
		nameLabel5 = GameObject.Find ("Name5").GetComponent < UILabel>();

		int score = PlayerPrefs.GetInt("1HighScore"); 
		scoreLabel1.text = score.ToString();

		score = PlayerPrefs.GetInt("2HighScore"); 
		scoreLabel2.text = score.ToString();

		score = PlayerPrefs.GetInt("3HighScore"); 
		scoreLabel3.text = score.ToString();

		score = PlayerPrefs.GetInt("4HighScore"); 
		scoreLabel4.text = score.ToString();

		score = PlayerPrefs.GetInt("5HighScore"); 
		scoreLabel5.text = score.ToString();

		// Names
		string name = PlayerPrefs.GetString("1Name"); 
		nameLabel1.text = name;

		name = PlayerPrefs.GetString("2Name"); 
		nameLabel2.text = name;

		name = PlayerPrefs.GetString("3Name"); 
		nameLabel3.text = name;

		name = PlayerPrefs.GetString("4Name"); 
		nameLabel4.text = name;

		name = PlayerPrefs.GetString("5Name"); 
		nameLabel5.text = name; 
	}

}
