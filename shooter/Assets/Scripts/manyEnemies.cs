using UnityEngine;
using System.Collections;

public class manyEnemies : MonoBehaviour {
	
	public GameObject basicEnemy;
	public GameObject medEnemy;
	//public GameObject hardEnemy;
	public float spawnAreaWidth;
	public float spawnAreaHeight;
	public int numOfEnemiesX;
	public int numOfEnemiesY;
	public float secondWaveTime;
	private bool secondReady = true;
	private bool thirdReady = true;
	public float thirdWaveTime;
	private float startTime;
	private float totalTime;
	
	// Use this for initialization
	void Start () {
		startTime = Time.time;
		for(int i = 0; i < numOfEnemiesX; i++){
			for(int j = 0; j < numOfEnemiesY; j++){
				Vector2 spawnPosition = transform.position;
				spawnPosition.x += i * (spawnAreaWidth/numOfEnemiesX);
				spawnPosition.y -= j * (spawnAreaHeight/numOfEnemiesY);
				Instantiate(basicEnemy,spawnPosition, basicEnemy.transform.rotation);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		totalTime = Time.time - startTime;
		if(totalTime > secondWaveTime && secondReady){
			spawnSecond();
		}
		if(totalTime > thirdWaveTime && thirdReady){
			spawnThird();
		}
		
	}
	
	void spawnSecond () {
		return;
	}
	void spawnThird () {
		return;
	}
}