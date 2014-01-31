using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour {

	public float speed = 2f;

	// Use this for initialization
	void Start () {

	}

	void Update () {
		
		if (transform.position.y < -7.5f) {
			transform.position = new Vector3 (-1.5f, 7.5f + (transform.position.y + 7.5f), 1);
		}

		transform.Translate(new Vector3(0, -1f * speed * Time.deltaTime, 0));
		
	}
}
