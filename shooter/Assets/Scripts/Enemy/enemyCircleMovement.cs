using UnityEngine;
using System.Collections;

public class enemyCircleMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0f,0f,Time.deltaTime*0.1f); // move forward
		
		transform.Rotate(0f,Time.deltaTime*0.1f,0f); // turn a little
	}
}
