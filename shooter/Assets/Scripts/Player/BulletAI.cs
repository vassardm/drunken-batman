using UnityEngine;
using System.Collections;

public class BulletAI : MonoBehaviour {
	
	public float xSpeed;
	public float ySpeed;
	public GameBehavior gameScript;
	
	// Use this for initialization
	void Start () {

		gameScript = Camera.main.GetComponent<GameBehavior>();
		Vector2 newVelocity = Vector2.zero;
		newVelocity.y = ySpeed;
		newVelocity.x = xSpeed;
		rigidbody2D.velocity = newVelocity;
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 newVelocity = Vector2.zero;
		newVelocity.y = ySpeed;
		newVelocity.x = xSpeed;
		rigidbody2D.velocity = newVelocity;
		
	}
	
	public void setSpeed(float x, float y){
		xSpeed = x;
		ySpeed = y;
	}

	public void bulletDestroy(){
		Destroy (gameObject);
	}
}

