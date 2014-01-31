using UnityEngine;
using System.Collections;

public class BGRotate : MonoBehaviour {

	public float speed = 3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.Rotate (0, speed, 0);

	}
}
