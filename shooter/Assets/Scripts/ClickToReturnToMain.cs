
using UnityEngine;
using System.Collections;

public class ClickToReturnToMain : MonoBehaviour {

	private float waitTime = 1f;
	private float startTime;
	
	// Use this for initialization
	void Start () {
		startTime = Time.time + waitTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > startTime){
			OnClick ();
		}
	}
	
	void OnClick() {
		string levelLoader = "AvastAlpha";
		Application.LoadLevel (levelLoader);
	}

}
