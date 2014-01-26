using UnityEngine;
using System.Collections;

public class PlayerInteraction : MonoBehaviour {

	public Vector3 respawnPoint = new Vector3(0, -4, 0);

	public GameBehavior gameScript;

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag.Equals("EnemyBullet")){
			respawn ();
		} else if (other.tag.Equals("Enemy")){
			respawn ();
		}
	}

	void respawn(){
		gameScript.numOfLives--;
		print ("lives left = " + gameScript.numOfLives);
		if (gameScript.numOfLives < 0) {
			Destroy (gameObject);
		} else {
			gameObject.transform.position = respawnPoint;
		}
	}

}
