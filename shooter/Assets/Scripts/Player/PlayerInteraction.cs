using UnityEngine;
using System.Collections;

public class PlayerInteraction : MonoBehaviour {

	public Vector3 respawnPoint = new Vector3(-1.5f, -1.5f, 0);

	public GameObject[] gibs;

	public float explosionForce;
	public float spawnRadius = 1.0f;
	public float invunTime = 1.0f;

	private float deathTime;
	private bool invun = false;

	public AudioClip playerLoseLife;
	public AudioClip playerDie;

	public GameBehavior gameScript;

	public ScoreStorage scoreStorage;

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag.Equals("EnemyBullet") && !invun){
			gameScript.grazeCounter = 0;
			gameScript.grazeMultiplier = 1;
			respawn ();
		} else if (other.tag.Equals("Enemy") && !invun){
			gameScript.grazeCounter = 0;
			gameScript.grazeMultiplier = 1;
			respawn ();
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
		int gameOverBenchmark = 0;
		deathTime = Time.time;
		gameScript.numOfLives--;
		gameScript.firePower = 0;
		print ("lives left = " + gameScript.numOfLives);

		foreach(GameObject gib in gibs)
		{
			GameObject gibInstance = Instantiate(gib,transform.position + Random.insideUnitSphere*spawnRadius,transform.rotation) as GameObject;
			gibInstance.rigidbody.AddExplosionForce(explosionForce,transform.position,spawnRadius);
		}
		
		if (gameScript.numOfLives < gameOverBenchmark) {
			AudioSource.PlayClipAtPoint(playerDie, transform.position);
			gameScript.audio.Stop();
			Destroy (gameObject);
			scoreStorage.score = gameScript.scoreCounter;
			Application.LoadLevel ("gameOverScene");
		} else {
			gameObject.transform.position = respawnPoint;
			invun = true;
			audio.PlayOneShot(playerLoseLife);
		}
	}

}
