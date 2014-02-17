using UnityEngine;
using System.Collections;

public class PickupItems : MonoBehaviour {

	public GameObject player;
	public GameBehavior gameScript;
	public AudioClip oneUpClip;
	public AudioClip fireUpClip;
	public AudioClip bombUpClip;
	public AudioClip pointsClip;
	public float volume = 0.4f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (player != null){
			transform.position = player.transform.position;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
				int scoreIncreaseByAfterCollectingPointItem = 500;
				int scoreMultipler = gameScript.grazeMultiplier;
				if (other.tag.Equals ("1UP")) {
						gameScript.numOfLives++;
						AudioSource.PlayClipAtPoint(oneUpClip, transform.position, volume);
						Destroy (other);
				} else if (other.tag.Equals ("extraBomb")) {
						if (gameScript.bombCounter < 8) {
								gameScript.bombCounter++;
						}
						AudioSource.PlayClipAtPoint(bombUpClip, transform.position, volume);
						Destroy (other);
				} else if (other.tag.Equals ("fireUp")) {
						gameScript.increaseFireRate ();
						AudioSource.PlayClipAtPoint(fireUpClip, transform.position, volume);
						Destroy (other);
				} else if (other.tag.Equals ("points")) {
						gameScript.scoreCounter += (scoreIncreaseByAfterCollectingPointItem * scoreMultipler);
						AudioSource.PlayClipAtPoint(pointsClip, transform.position, volume);
						Destroy (other);
				}
		}
}
