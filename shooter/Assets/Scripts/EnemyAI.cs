using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public GameObject enemyBullet;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.X))
		{
			//Creates an object, giving it position, and 
			Instantiate(enemyBullet,transform.position,transform.rotation);
		}	
	}
}
