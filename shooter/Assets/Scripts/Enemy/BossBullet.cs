using UnityEngine;
using System.Collections;

public class BossBullet : MonoBehaviour {

	public GameBehavior globals;
	public float velocity = -3.0f;
	public bool entered = false; // You need this flag or the game will try to read EVERY instance of the collison!
	
	// Use this for initialization
	void Start () {
		
		Vector2 newVelocity = Vector2.zero;
		float rotation = gameObject.transform.eulerAngles.z;
		//print ("rotation" + rotation);
		newVelocity.y = -Mathf.Cos (rotation * Mathf.Deg2Rad) * velocity;
		newVelocity.x = Mathf.Sin (rotation * Mathf.Deg2Rad) * velocity;
		rigidbody2D.velocity = newVelocity;
		globals = Camera.main.GetComponent<GameBehavior>();
		
	}
	
	void OnTriggerEnter2D(Collider2D other){
		
		/*int levelOneGrazeBenchmark = 4;
		int levelTwoGrazeBenchmark = 9;
		int levelThreeGrazeBenchmark = 15;*/
		
		if (other.tag == "graze_trigger") {
			if (!entered) {
				print ("in boss graze trigger");
				globals.updateGraze();
				//print ("in graze trigger");
				/*globals.grazeCounter++;
				if(globals.grazeCounter > levelOneGrazeBenchmark && globals.grazeCounter <= levelTwoGrazeBenchmark){
					//print ("graze level = 2");
					globals.grazeMultiplier = 2;
				}
				if(globals.grazeCounter > levelTwoGrazeBenchmark && globals.grazeCounter <= levelThreeGrazeBenchmark){
					//print ("graze level = 4");
					globals.grazeMultiplier = 4;
				}
				if(globals.grazeCounter > levelThreeGrazeBenchmark){
					//print ("graze level = 8");
					globals.grazeMultiplier = 8;
				}*/
				entered = true;
			}
		}else if (other.tag == "pickup") {
			// Do Nothing				
		} else {
			Destroy (gameObject);
		}
	}
}
