using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public GameObject enemyBullet;
	public float shootSpeed;
	public float time;
	public float startShootTime;
	public GameObject oneUp;
	public GameObject extraBomb;
	public GameObject fireRate;
	public GameObject points;

	public GameBehavior gameScript;

	// Use this for initialization
	void Start () {
		time = Time.time + shootSpeed + startShootTime;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.X))
		{
			//Creates an object, giving it position, and 
			Instantiate(enemyBullet,transform.position,transform.rotation);
		}

		if (Time.time > time) {
			Instantiate(enemyBullet, transform.position, transform.rotation);
			time += shootSpeed;
		}

	}

	void OnTriggerEnter2D(Collider2D other){
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
		if(!other.tag.Equals("Player")){
			BulletAI bulletAI = other.GetComponent<BulletAI>();
			bulletAI.bulletDestroy();
		}

		Destroy (gameObject);
	}

	public void setGameScript(Camera cam){
		gameScript = cam.GetComponent<GameBehavior>();
	}
}
