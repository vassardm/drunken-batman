using UnityEngine;
using System.Collections;

public class PlayerInteraction : MonoBehaviour {

	public Vector3 respawnPoint = new Vector3(-1.5f, -1.5f, 0);
	public GameObject[] gibs;
	public float explosionForce;
	public float spawnRadius = 1.0f;
	public float invunTime;
	private float deathTime;
	private bool invun = false;

	public GameBehavior gameScript;

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag.Equals("EnemyBullet") && !invun){
			respawn ();
		} else if (other.tag.Equals("Enemy") && !invun){
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
			gameScript.increaseFireRate();
			Destroy(other);
		}
		else if (other.tag.Equals("points")){
			gameScript.scoreCounter += 5;
			Destroy(other);
		}
	}

	void Update(){
		if(invun){
			if(Time.time - deathTime > invunTime){
				invun = false;
			}
		}
	}

	public GameBehavior getGlobals(){
		return gameScript;
	}

	void respawn(){
		deathTime = Time.time;
		gameScript.numOfLives--;
		gameScript.firePower = 0;
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
			invun = true;
		}
	}

}
