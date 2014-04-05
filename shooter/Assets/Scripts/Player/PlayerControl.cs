using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float normalSpeed = 4.5f;
	public float focusSpeed = 1.85f;
	public float padding = 20.0f;
	private float speed;

    private const float RIGHT_WIN_PADDING = 320f;
    private const float LEFT_WIN_PADDING = 35f;
    private const float TOP_WIN_PADDING = 70f;
    private const float BOTTOM_WIN_PADDING = 90f;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.LeftShift)) {
			speed = focusSpeed;
		} else {
			speed = normalSpeed;
		}

		transform.position = new Vector2(restrictHorizontal(), restrictVertical());
	}

	float restrictHorizontal() {

		Vector2 newPosition = transform.position;
		
		if ((Camera.main.WorldToScreenPoint(transform.position).x > Screen.width - padding - RIGHT_WIN_PADDING)){
			if(Input.GetAxis("Horizontal") < 0){
				newPosition.x += (Input.GetAxis("Horizontal") * speed * Time.deltaTime);
			}
		}
		
		else if ((Camera.main.WorldToScreenPoint(transform.position).x < 0 + padding + LEFT_WIN_PADDING)){
			if(Input.GetAxis("Horizontal") > 0){
				newPosition.x += (Input.GetAxis("Horizontal") * speed * Time.deltaTime);
			}
		}
		
		else {
			newPosition.x += (.5f * (Input.GetAxis("Horizontal") * speed * Time.deltaTime));
            //newPosition.x += 0;
		}

		return newPosition.x;

	}

	float restrictVertical() {

		Vector2 newPosition = transform.position;
		
		if ((Camera.main.WorldToScreenPoint(transform.position).y > Screen.height - padding - TOP_WIN_PADDING)){
			if(Input.GetAxis("Vertical") < 0){
				newPosition.y += (Input.GetAxis("Vertical") * speed * Time.deltaTime);
			}
		}
		
		else if ((Camera.main.WorldToScreenPoint(transform.position).y < 0 + padding + BOTTOM_WIN_PADDING)){
			if(Input.GetAxis("Vertical") > 0){
				newPosition.y += (Input.GetAxis("Vertical") * speed * Time.deltaTime);
			}
		}
		
		else {
			newPosition.y += (0.5f * (Input.GetAxis("Vertical") * speed * Time.deltaTime));
		}
		
		return newPosition.y;
		
	}
}
