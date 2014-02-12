using UnityEngine;
using System.Collections;

public class MedEnemyAI : MonoBehaviour {

	public float shootSpeed;
	public float time;
	public float startShootTime;

	public GameObject enemyBullet;
	public GameObject oneUp;
	public GameObject extraBomb;
	public GameObject fireRate;
	public GameObject points;

	public int health;
	
	public GameBehavior gameScript;
	
	// Use this for initialization
	void Start () {
		time = Time.time + shootSpeed + startShootTime;
		health = 3;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > time) {
			Instantiate(enemyBullet, transform.position, transform.rotation);
			time += shootSpeed;
		}		
	}
	
	void OnTriggerEnter2D(Collider2D other) {

		int increaseEnemyKilledScoreBy = 1000; // This is how many points you gain from killing a more difficult foe
		int scoreMultiplier = gameScript.grazeMultiplier;
		int deathHPBenchmark = 1;
		int randomNumberFloor = 1;
		int randomNumberCeiling = 100;
		int getLifeUpItemBenchmark = 10;
		int getBombUpItemBenchmark = 80;
		int getIncreaseFireRateItemBenchmark = 40;
		int getIncreasePointScoreBenchmark = 10;

		if (other.tag.Equals("PlayerBullet")){
			health--;
			BulletAI bulletAI = other.GetComponent<BulletAI>();
			bulletAI.bulletDestroy();		
		}

		else if (other.tag.Equals("Player")) {
			health--;
		}

		if (other.tag != "graze_trigger") {
			
			gameScript.scoreCounter += (increaseEnemyKilledScoreBy * scoreMultiplier);
			print ("score = " + gameScript.scoreCounter);
			var randNumb = Random.Range (randomNumberFloor, randomNumberCeiling);
			
			if (randNumb >= randomNumberFloor && randNumb <= getLifeUpItemBenchmark) {
				Instantiate (points, transform.position, transform.rotation);
				print ("extra life");
			} else if (randNumb >= getBombUpItemBenchmark && randNumb <= randomNumberCeiling) {
				Instantiate (extraBomb, transform.position, transform.rotation);
				print ("extra bomb");
			} else if (randNumb >= getIncreaseFireRateItemBenchmark && randNumb < getBombUpItemBenchmark) {
				Instantiate (fireRate, transform.position, transform.rotation);
				print ("fire rate");
			} else if (randNumb > getIncreasePointScoreBenchmark && randNumb < getIncreaseFireRateItemBenchmark) {
				Instantiate (points, transform.position, transform.rotation);
				print ("more points");
			}
			
			if (!other.tag.Equals ("Player")) {
				BulletAI bulletAI = other.GetComponent<BulletAI> ();
				bulletAI.bulletDestroy ();
			}
			//	AudioSource.PlayClipAtPoint (enemyDies, transform.position);
			Destroy (gameObject);
		}
	}
}

