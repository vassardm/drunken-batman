using UnityEngine;
using System.Collections;

public class PickupItems : MonoBehaviour {

	public GameObject player;
	public GameBehavior gameScript;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = player.transform.position;
	}

	void OnTriggerEnter2D(Collider2D other){
				int scoreIncreaseByAfterCollectingPointItem = 500;
				int scoreMultipler = gameScript.grazeMultiplier;
				if (other.tag.Equals ("1UP")) {
						gameScript.numOfLives++;
						Destroy (other);
				} else if (other.tag.Equals ("extraBomb")) {
						if (gameScript.bombCounter < 8) {
								gameScript.bombCounter++;
						}
						Destroy (other);
				} else if (other.tag.Equals ("fireUp")) {
						gameScript.increaseFireRate ();
						Destroy (other);
				} else if (other.tag.Equals ("points")) {
						gameScript.scoreCounter += (scoreIncreaseByAfterCollectingPointItem * scoreMultipler);
						Destroy (other);
				}
		}
}
