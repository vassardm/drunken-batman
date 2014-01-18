using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public GameObject enemyBullet;
	public float shootSpeed;
	public float time;
	public float startShootTime;

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

	void OnTriggerEnter2D(){
		Destroy (gameObject);
	}
}
