using UnityEngine;
using System.Collections;

public class PlayerInteraction : MonoBehaviour {

	public Vector3 respawnPoint = new Vector3(0, -4, 0);
	public GameObject[] gibs;
	public float explosionForce;
	public float spawnRadius = 1.0f;

	public GameBehavior gameScript;

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag.Equals("EnemyBullet")){
			respawn ();
		} else if (other.tag.Equals("Enemy")){
			respawn ();
		}
		else if (other.tag.Equals("1UP")){
			gameScript.numOfLives++;
			print ("got it");
			Destroy(other);
		}
		else if (other.tag.Equals("extraBomb")){
			gameScript.bombCounter++;
			print ("got it");
			Destroy(other);
		}
		else if (other.tag.Equals("fireUp")){
			gameScript.fireRate -= .05f;
			Destroy(other);
		}
		else if (other.tag.Equals("points")){
			gameScript.scoreCounter += 5;
			Destroy(other);
		}
	}

	void respawn(){
		gameScript.numOfLives--;
		print ("lives left = " + gameScript.numOfLives);
		foreach(GameObject gib in gibs)
		{
			GameObject gibInstance = Instantiate(gib,transform.position + Random.insideUnitSphere*spawnRadius,transform.rotation) as GameObject;
			gibInstance.rigidbody.AddExplosionForce(explosionForce,transform.position,spawnRadius);
		}
		if (gameScript.numOfLives < 0) {
			Destroy (gameObject);
		} else {
			gameObject.transform.position = respawnPoint;
		}
	}

}
