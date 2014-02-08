using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float normalSpeed = 10.0f;
	public float focusSpeed = 5.0f;
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

	float restrictHorizontal(){

		Vector2 newPosition = transform.position;		
		
		if((Camera.main.WorldToScreenPoint(transform.position).x > Screen.width - padding - 320f)){
			if(Input.GetAxis("Horizontal") < 0){
				newPosition.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
			}
		}
		
		else if((Camera.main.WorldToScreenPoint(transform.position).x < 0 + padding + 35f)){
			if(Input.GetAxis("Horizontal") > 0){
				newPosition.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
			}
		}
		
		else{
			newPosition.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
		}

		return newPosition.x;

	}

	float restrictVertical(){

		Vector2 newPosition = transform.position;		
		
		if((Camera.main.WorldToScreenPoint(transform.position).y > Screen.height - padding - 70f)){
			if(Input.GetAxis("Vertical") < 0){
				newPosition.y += Input.GetAxis("Vertical") * speed * Time.deltaTime;
			}
		}
		
		else if((Camera.main.WorldToScreenPoint(transform.position).y < 0 + padding + 75f)){
			if(Input.GetAxis("Vertical") > 0){
				newPosition.y += Input.GetAxis("Vertical") * speed * Time.deltaTime;
			}
		}
		
		else{
			newPosition.y += Input.GetAxis("Vertical") * speed * Time.deltaTime;
		}
		
		return newPosition.y;
		
	}
}
