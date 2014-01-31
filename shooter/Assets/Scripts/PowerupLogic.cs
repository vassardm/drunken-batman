using UnityEngine;
using System.Collections;

public class PowerupLogic : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Vector2 newVel = transform.rigidbody2D.velocity;
		newVel.y = -2f;
		transform.rigidbody2D.velocity = newVel;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		Destroy(gameObject);
	}
}
