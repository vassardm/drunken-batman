using UnityEngine;
using System.Collections;

public class manyEnemies : MonoBehaviour {
	
	public GameObject basicEnemy;
	public GameObject horEnemy;
	public GameObject vertEnemy;
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
		EnemyAI bEnAI = basicEnemy.GetComponent<EnemyAI>();
		EnemyAI hEnAI = horEnemy.GetComponent<EnemyAI>();
		EnemyAI vEnAI = vertEnemy.GetComponent<EnemyAI>();
		for(int i = 0; i < numOfEnemiesX; i++){
			for(int j = 0; j < numOfEnemiesY; j++){
				Vector2 spawnPosition = transform.position;
				spawnPosition.x += i * (spawnAreaWidth/numOfEnemiesX);
				spawnPosition.y -= j * (spawnAreaHeight/numOfEnemiesY);
				if(i%2 == 0){
					Instantiate(vertEnemy,spawnPosition, basicEnemy.transform.rotation);
					float enShootSpeed = vEnAI.shootSpeed;
					vEnAI.setTime(Random.Range(0,  (int)enShootSpeed*10)/10);
				}
				else{
					Instantiate(horEnemy,spawnPosition, basicEnemy.transform.rotation);
					float enShootSpeed = hEnAI.shootSpeed;
					hEnAI.setTime(Random.Range(0,  (int)enShootSpeed*10)/10);
				}
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