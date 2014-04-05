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
        /*
        Vector2 newPosition = new Vector2();
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            newPosition.x = MoveLeft();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight();
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            newPosition.y = MoveDown();
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            newPosition.y = MoveUp();
        }
        */
		transform.position = new Vector2(restrictHorizontal(), restrictVertical());
       // transform.position = newPosition;
	}

    private float MoveLeft()
    {
        if (Camera.main.WorldToScreenPoint(transform.position).x > Screen.width - padding - RIGHT_WIN_PADDING)
        {
            print("LEFT" + transform.position.x);
            return transform.position.x - (speed * Time.deltaTime);

        }
        else
        {
            print("LEFT NOT IN WORLD" + transform.position.x);
            return transform.position.x;
        }

        return transform.position.x - (speed * Time.deltaTime);
    }

    private void MoveRight()
    {
        print("Getting right input!");
        if (Camera.main.WorldToScreenPoint(transform.position).x < 0 + padding + LEFT_WIN_PADDING)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }

    private float MoveDown()
    {
        if (Camera.main.WorldToScreenPoint(transform.position).y > Screen.height - padding - TOP_WIN_PADDING)
        {
            return transform.position.y - (speed * Time.deltaTime);
        }
        else
        {
            return transform.position.y;
        }
    }

    private float MoveUp()
    {
        if (Camera.main.WorldToScreenPoint(transform.position).y < 0 + padding + BOTTOM_WIN_PADDING)
        {
            return transform.position.y + (speed * Time.deltaTime);
        }
        else
        {
            return transform.position.y;
        }
    }

	float restrictHorizontal() {

		Vector2 newPosition = transform.position;	
		float rightWindowPadding = 320f;
		float leftWindowPadding = 35f;
		
		if ((Camera.main.WorldToScreenPoint(transform.position).x > Screen.width - padding - rightWindowPadding)){
			if(Input.GetAxis("Horizontal") < 0){
				newPosition.x += (Input.GetAxis("Horizontal") * speed * Time.deltaTime);
			}
		}
		
		else if ((Camera.main.WorldToScreenPoint(transform.position).x < 0 + padding + leftWindowPadding)){
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
		float topWindowPadding = 70f;
		float bottomWindowPadding = 90f;
		
		if ((Camera.main.WorldToScreenPoint(transform.position).y > Screen.height - padding - topWindowPadding)){
			if(Input.GetAxis("Vertical") < 0){
				newPosition.y += (Input.GetAxis("Vertical") * speed * Time.deltaTime);
			}
		}
		
		else if ((Camera.main.WorldToScreenPoint(transform.position).y < 0 + padding + bottomWindowPadding)){
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
