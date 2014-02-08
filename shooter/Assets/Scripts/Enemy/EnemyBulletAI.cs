using UnityEngine;
using System.Collections;

public class EnemyBulletAI : MonoBehaviour {

	public GameBehavior globals;
	public bool entered = false;

	// Use this for initialization
	void Start () {

		Vector2 newVelocity = Vector2.zero;
		newVelocity.y = -3.0f;
		rigidbody2D.velocity = newVelocity;
		globals = Camera.main.GetComponent<GameBehavior>();
	
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "graze_trigger") {
			if (!entered){
				print ("in graze trigger");
				globals.grazeCounter++;
				if(globals.grazeCounter > 15 && globals.grazeCounter <= 31){
					print ("graze level = 2");
					globals.grazeMultiplier = 2;
				}
				if(globals.grazeCounter > 31 && globals.grazeCounter <= 63){
					print ("graze level = 4");
					globals.grazeMultiplier = 4;
				}
				if(globals.grazeCounter > 63){
					print ("graze level = 8");
					globals.grazeMultiplier = 8;
				}
				entered = true;
			}
		} else {
			Destroy (gameObject);
		}
	}
}
