using UnityEngine;
using System.Collections;

public class MedEnemyAI : MonoBehaviour {

	public GameObject enemyBullet;
	public float shootSpeed;
	public float time;
	public float startShootTime;
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
			gameScript.scoreCounter++;
			print ("score = " + gameScript.scoreCounter);
			var randNumb = Random.Range(1, 100);
			if(randNumb <= 5){
				Instantiate(points, transform.position, transform.rotation);
				print ("extra life");
			}
			else if(randNumb >= 90){
				Instantiate(extraBomb, transform.position, transform.rotation);
				print ("extra bomb");
			}
			else if(randNumb >= 80){
				Instantiate(fireRate, transform.position, transform.rotation);
				print ("fire rate");
			}
			else if(randNumb >= 70){
				Instantiate(points, transform.position, transform.rotation);
				print ("more points");
			}
			Destroy (gameObject);
		}
	}
}

