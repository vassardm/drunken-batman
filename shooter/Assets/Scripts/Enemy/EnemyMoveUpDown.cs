using UnityEngine;
using System.Collections;

public class EnemyMoveUpDown : MonoBehaviour {
	
	private float moveTime = .5f;
	private float changeTime;
	private float speed = 1.5f;
	private int direction;
	
	// Use this for initialization
	void Start () {
		changeTime = Time.time + moveTime/2;
		direction =-1;
	}
	
	// Update is called once per frame
	void Update () {
		if(changeTime < Time.time){
			direction = direction*(-1);
			changeTime = Time.time + moveTime;
		}
		Vector3 newPos = transform.position;
		newPos.y += direction * speed * Time.deltaTime;
		transform.position = newPos;
	}
	
	public void setDirection(int dir){
		direction = dir;
	}
}