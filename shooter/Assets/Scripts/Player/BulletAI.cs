using UnityEngine;
using System.Collections;

public class BulletAI : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {

		Vector2 newVelocity = Vector2.zero;
		newVelocity.y = speed;
		rigidbody2D.velocity = newVelocity;
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}
}
