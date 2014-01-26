using UnityEngine;
using System.Collections;

public class GameBehavior : MonoBehaviour {

	public int scoreCounter = 0;
	public int numOfLives = 4;

	// Use this for initialization
	void Start () {
	
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
	}
}
