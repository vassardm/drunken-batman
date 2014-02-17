using UnityEngine;
using System.Collections;

public class ReturnToMainMenu : MonoBehaviour {

	private float waitTime = 1f;
	private float startTime;

	void Start(){
		startTime = Time.time + waitTime;
	}

	// Update is called once per frame
	void Update () {
		if (Time.time > startTime){
			if (Input.anyKey) {
				string levelLoader = "AvastAlpha";
				Application.LoadLevel (levelLoader);
			}
		}
	}

}

