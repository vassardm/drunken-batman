using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick() {
		Application.LoadLevel ("gameScene");
		print ("1High score: " + PlayerPrefs.GetInt("1HighScore"));
		print ("2High score: " + PlayerPrefs.GetInt("2HighScore"));
		print ("3High score: " + PlayerPrefs.GetInt("3HighScore"));
		print ("4High score: " + PlayerPrefs.GetInt("4HighScore"));

	}
}
