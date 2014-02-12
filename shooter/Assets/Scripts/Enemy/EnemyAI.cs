using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public GameObject enemyBullet;
	public GameObject oneUp;
	public GameObject extraBomb;
	public GameObject fireRate;
	public GameObject points;

	public float shootSpeed;
	public float time;
	public float startShootTime = 0;

	public GameBehavior gameScript;

	// Use this for initialization
	void Start () {
		//time = Time.time + shootSpeed + startShootTime;
		gameScript = Camera.main.GetComponent<GameBehavior>();
	}

	public void setTime(float startTime){
		time = Time.time + shootSpeed + startTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > time) {
			Instantiate(enemyBullet, transform.position, transform.rotation);
			time += shootSpeed;
		}

	}

	void OnTriggerEnter2D(Collider2D other){
		int increaseEnemyKilledScoreBy = 100; // This is how many points you gain from killing a foe.
		int scoreMultiplier = gameScript.grazeMultiplier;
		int randomNumberFloor = 1;
		int randomNumberCeiling = 100;
		int getLifeUpItemBenchmark = 10;
		int getBombUpItemBenchmark = 90;
		int getIncreaseFireRateItemBenchmark = 60;
		int getIncreasePointScoreBenchmark = 10;
		

		if (other.tag.Equals("Player") || other.tag.Equals("PlayerBullet")) {

			gameScript.scoreCounter += (increaseEnemyKilledScoreBy * scoreMultiplier);
			Destroy (gameObject);
			gameScript.enemiesKilled++;
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

			if (other.tag.Equals ("PlayerBullet")) {
					BulletAI bulletAI = other.GetComponent<BulletAI> ();
					bulletAI.bulletDestroy ();
			}
			//	AudioSource.PlayClipAtPoint (enemyDies, transform.position);

		}
	}

}
