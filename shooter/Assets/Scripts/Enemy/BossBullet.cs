using UnityEngine;
using System.Collections;

public class BossBullet : MonoBehaviour {

	public GameBehavior globals;
	public float velocity;
	public bool grazeTrigger = false;
	public bool entered = false; // You need this flag or the game will try to read EVERY instance of the collison!

    private THorseSystemMechanics th;
	
	// Use this for initialization
	void Start () {

        th = Camera.main.GetComponent<THorseSystemMechanics>();
		
		Vector2 newVelocity = Vector2.zero;
		float rotation = gameObject.transform.eulerAngles.z;
		//print ("rotation" + rotation);
		newVelocity.y = -Mathf.Cos (rotation * Mathf.Deg2Rad) * (velocity + th.GetModifier(3));
		newVelocity.x = Mathf.Sin (rotation * Mathf.Deg2Rad) * (velocity + th.GetModifier(3));
		rigidbody2D.velocity = newVelocity;
		globals = Camera.main.GetComponent<GameBehavior>();
		
	}
	
	void OnTriggerEnter2D(Collider2D other){
		
		if (other.tag == "graze_trigger") {
			if (!entered) {
				print ("in boss graze trigger");
				globals.updateGraze();
				entered = true;
				grazeTrigger = true;
			}
		}else if (other.tag == "pickup") {
			// Do Nothing				
		} else {
			Destroy (gameObject);
		}
	}
}
