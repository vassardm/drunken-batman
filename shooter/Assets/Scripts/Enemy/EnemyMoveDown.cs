using UnityEngine;
using System.Collections;

public class EnemyMoveDown : MonoBehaviour {

	public float speed = 3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		Vector3 newPos = transform.position;
		newPos.y -= speed * Time.deltaTime;
		transform.position = newPos;
	}
}
