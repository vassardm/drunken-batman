using UnityEngine;
using System.Collections;

public class TestTransfer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var scoreStorageObject = GameObject.Find ("ScoreStorageObject");
		ScoreStorage scoreStorage = scoreStorageObject.GetComponent<ScoreStorage>();
		print (scoreStorage.score);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
