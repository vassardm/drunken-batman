
using UnityEngine;
using System.Collections;

public class ClickToReturnToMain : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		OnClick ();
	}
	
	void OnClick() {
		string levelLoader = "AvastAlpha";
		Application.LoadLevel (levelLoader);
	}
}
