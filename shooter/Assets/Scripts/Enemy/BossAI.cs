using UnityEngine;
using System.Collections;

public class BossAI : MonoBehaviour {

	public GameObject bossBullet;
	public float shootSpeed;
	public float time;
	public float startShootTime;
	public int health;
	public int numBullets;
	public float angle = 0.0f;
	public float angleIncrement = 0.0001f;
	
	public GameBehavior gameScript;

	// Use this for initialization
	void Start () {
		gameScript = Camera.main.GetComponent<GameBehavior> ();
		time = Time.time + shootSpeed + startShootTime;
		health = 150;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameScript.paused){
			if (Time.time > time) {
				for (int i = 0; i < numBullets; i++) {
					Instantiate(bossBullet, transform.position, Quaternion.Euler (0, 0, i * (360 / numBullets) + angle));
				}

				float randomNumberAngleFloor = 5.0f;
				float randomNumberAngleCeiling = 13.0f;
				var varyingAngleIncNumb = Random.Range (randomNumberAngleFloor, randomNumberAngleCeiling);
				angle += varyingAngleIncNumb;

				float randomNumberFloor = 0.25f;
				float randomNumberCeiling = 0.75f;
				var varyingShootSpeedNumb = Random.Range (randomNumberFloor, randomNumberCeiling);
				time += varyingShootSpeedNumb;
				//angle += angleIncrement;
				//time += shootSpeed;
			}	
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag.Equals("PlayerBullet")){
			health--;
			BulletAI bulletAI = other.GetComponent<BulletAI>();
			bulletAI.bulletDestroy();
			
		}
		else if(other.tag.Equals("Player")){
			health--;
		}
		if(health < 1){
			int increaseEnemyKilledScoreBy = 10000; // This is how many points you gain from killing a foe.
			int scoreMultiplier = gameScript.grazeMultiplier;
			gameScript.scoreCounter += (increaseEnemyKilledScoreBy * scoreMultiplier);
			gameScript.checkIfHighScore();
			print ("score = " + gameScript.scoreCounter);
			gameScript.bossKilled = true;
			Destroy (gameObject);
		}
	}
}
