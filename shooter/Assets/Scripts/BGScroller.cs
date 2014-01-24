using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour {

	public float speed = 2;

	// Use this for initialization
	void Start () {

	}

	void FixedUpdate () {

		if (Camera.main.WorldToScreenPoint (transform.position).y < 0 - (Screen.height / 2)) {
			transform.position = new Vector3 (0, 10 - (speed * Time.deltaTime), 1);
		} else {
			Vector3 newPos = transform.position;
			newPos.y -= speed * Time.deltaTime;
			transform.position = newPos;
		}

	}
}
