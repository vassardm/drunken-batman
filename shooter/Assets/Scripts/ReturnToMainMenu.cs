using UnityEngine;
using System.Collections;

public class ReturnToMainMenu : MonoBehaviour {

	private float waitTime = 1f;
	private float startTime;
	private UIInput inputText;

	void Start(){
		startTime = Time.time + waitTime;
		inputText = GameObject.Find ("inputText").GetComponent < UIInput>();
	}

	// Update is called once per frame
	void Update () {
		if (Time.time > startTime){
			if (Input.GetKey (KeyCode.KeypadEnter) || Input.GetKey (KeyCode.Return)) {
				string newName = inputText.value;
				print (newName);

				int newScore = PlayerPrefs.GetInt ("savedScore");
				int oldScore;
				string oldName;

				for (int i = 1; i < 6; i++) {
					if (PlayerPrefs.GetInt (i + "HighScore") < newScore) {
						oldScore = PlayerPrefs.GetInt(i + "HighScore");
						oldName = PlayerPrefs.GetString (i + "Name");
						
						PlayerPrefs.SetInt(i + "HighScore", newScore);
						PlayerPrefs.SetString(i + "Name", newName.ToUpper ());
						
						newScore = oldScore;
						newName = oldName;
					} 
				}

				string levelLoader = "AvastAlpha";
				Application.LoadLevel (levelLoader);
			}
		}
	}

}

