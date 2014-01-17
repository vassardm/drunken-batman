using UnityEngine;
using System.Collections;

public class EnemyBulletAI : MonoBehaviour {

	// Use this for initialization
	void Start () {

		Vector2 newVelocity = Vector2.zero;
		newVelocity.y = -10.0f;
		rigidbody2D.velocity = newVelocity;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
