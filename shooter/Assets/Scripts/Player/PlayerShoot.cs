using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	public GameObject bullet;
	public float bulletSpeed;
	public float firingRate;
	public float lastFired = -100f;
	public GameBehavior gameScript;

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
				GameObject bullets = (Instantiate(bullet,transform.position,transform.rotation)) as GameObject;
				BulletAI ai = bullets.GetComponent<BulletAI>();
				ai.setSpeed(0, bulletSpeed);
				lastFired = Time.time;
			}
		}	

		if(Input.GetKeyDown(KeyCode.X))
		{
			if (gameScript.bombCounter > 0){
				gameScript.bombCounter--;
				for(int i = -6; i < 6; i++){
					GameObject bullets = (Instantiate(bullet,transform.position,transform.rotation)) as GameObject;
					BulletAI ai = bullets.GetComponent<BulletAI>();

					ai.setSpeed(i/2.0f, bulletSpeed);
				}
			}
		}

	}
}
