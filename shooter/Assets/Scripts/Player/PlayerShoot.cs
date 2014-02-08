using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	public GameObject bullet;
	public float bulletSpeed;
	private float firingRate;
	public float lastFired = -100f;
	public GameBehavior gameScript;
	public AudioClip playerBomb;
	public AudioClip playerShoot;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		firingRate = gameScript.fireRate;
		if(Input.GetKey(KeyCode.Z))
		{
			//Creates an object, giving it position, and 
			/*GameObject bullets = (Instantiate(bullet,transform.position,transform.rotation)) as GameObject;
			BulletAI ai = bullets.GetComponent<BulletAI>();
			ai.setSpeed(0, bulletSpeed);*/
			//Instantiate(bullet, transform.position, transform.rotation);
			if (Time.time >= lastFired + firingRate){
				for(int i = 0; i < gameScript.numOfBullets; i++){
					Vector3 bulletPos = transform.position;
					bulletPos.x = transform.position.x + ((-(gameScript.numOfBullets - 1)/2) + ((gameScript.numOfBullets - 1)*(i)))/5;
					GameObject bullets = (Instantiate(bullet, bulletPos,transform.rotation)) as GameObject;
					BulletAI ai = bullets.GetComponent<BulletAI>();
					ai.setSpeed(0, bulletSpeed);
				}
				lastFired = Time.time;
				audio.PlayOneShot (playerShoot);
			}
		}	

		if(Input.GetKeyDown(KeyCode.X))
		{
			if (gameScript.bombCounter > 0){
				gameScript.grazeCounter = 0;
				gameScript.grazeMultiplier = 1;
				gameScript.bombCounter--;
				for(int i = -6; i < 6; i++){
					GameObject bullets = (Instantiate(bullet,transform.position,transform.rotation)) as GameObject;
					BulletAI ai = bullets.GetComponent<BulletAI>();

					ai.setSpeed(i/2.0f, bulletSpeed);
				}
				audio.PlayOneShot(playerBomb);
			}
		}

	}
}
