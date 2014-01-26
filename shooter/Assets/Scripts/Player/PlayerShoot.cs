using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	public GameObject bullet;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Z))
		{
			//Creates an object, giving it position, and 
			Instantiate(bullet,transform.position,transform.rotation);
		}	
	}
}
