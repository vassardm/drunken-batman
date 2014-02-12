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
	private float moveTime = .5f;
	private float changeTime;
	private float speed = 1.5f;
	public int vDirection;
	public int hDirection;
	
	public GameBehavior gameScript;
	
	// Use this for initialization
	void Start () {
		gameScript = Camera.main.GetComponent<GameBehavior>();
		time = Time.time + shootSpeed + startShootTime;
		health = 3;
		changeTime = Time.time + moveTime/2;
		vDirection = 1;
		hDirection = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > time) {
			Instantiate(enemyBullet, transform.position, transform.rotation);
			time += shootSpeed;
		}
		if(changeTime < Time.time){
			hDirection = hDirection*(-1);
			vDirection = vDirection*(-1);
			changeTime = Time.time + moveTime;
		}
		Vector3 newPos = transform.position;
		newPos.x += hDirection * speed * Time.deltaTime;
		newPos.y += vDirection * speed * Time.deltaTime;
		transform.position = newPos;
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
		if(health < 1){
			Destroy (gameObject);
			gameScript.enemiesKilled++;
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

		}
	}

	public void setDirection(int hDir, int vDir){
		hDirection = hDir;
		vDirection = vDir;
	}

	public void setTime(float startTime){
		time = Time.time + shootSpeed + startTime;
	}
}

