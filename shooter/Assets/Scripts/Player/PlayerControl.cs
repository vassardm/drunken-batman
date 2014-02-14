using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float normalSpeed = 3.25f;
	public float focusSpeed = 0.95f;
	public float padding = 20.0f;
	private float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector2 newPosition = transform.position;	

		if (Input.GetKey(KeyCode.LeftShift)) {
			speed = focusSpeed;
		} else {
			speed = normalSpeed;
		}

		newPosition.x = restrictHorizontal();
		newPosition.y = restrictVertical();


		transform.position = newPosition;
	}

	float restrictHorizontal() {

		Vector2 newPosition = transform.position;	
		float rightWindowPadding = 320f;
		float leftWindowPadding = 35f;
		
		if ((Camera.main.WorldToScreenPoint(transform.position).x > Screen.width - padding - rightWindowPadding)){
			if(Input.GetAxis("Horizontal") < 0){
				newPosition.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
			}
		}
		
		else if ((Camera.main.WorldToScreenPoint(transform.position).x < 0 + padding + leftWindowPadding)){
			if(Input.GetAxis("Horizontal") > 0){
				newPosition.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
			}
		}
		
		else {
			newPosition.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
		}

		return newPosition.x;

	}

	float restrictVertical() {

		Vector2 newPosition = transform.position;
		float topWindowPadding = 70f;
		float bottomWindowPadding = 90f;
		
		if ((Camera.main.WorldToScreenPoint(transform.position).y > Screen.height - padding - topWindowPadding)){
			if(Input.GetAxis("Vertical") < 0){
				newPosition.y += Input.GetAxis("Vertical") * speed * Time.deltaTime;
			}
		}
		
		else if ((Camera.main.WorldToScreenPoint(transform.position).y < 0 + padding + bottomWindowPadding)){
			if(Input.GetAxis("Vertical") > 0){
				newPosition.y += Input.GetAxis("Vertical") * speed * Time.deltaTime;
			}
		}
		
		else {
			newPosition.y += Input.GetAxis("Vertical") * speed * Time.deltaTime;
		}
		
		return newPosition.y;
		
	}
}
