using UnityEngine;
using System.Collections;

public class PlayerInteraction : MonoBehaviour {

	public int numOfLives = 4;
	public Vector3 respawnPoint = new Vector3(0, -4, 0);

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag.Equals("EnemyBullet")){
			respawn ();
		} else if (other.tag.Equals("Enemy")){
			respawn ();
		}
	}

	void respawn(){
		numOfLives--;
		if (numOfLives < 0) {
			Destroy (gameObject);
		} else {
			gameObject.transform.position = respawnPoint;
		}
	}

}
