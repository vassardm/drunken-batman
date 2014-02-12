using UnityEngine;
using System.Collections;

public class manyEnemies : MonoBehaviour {
	
	public GameObject basicEnemy;
	public GameObject horEnemy;
	public GameObject vertEnemy;
	public GameObject medEnemy;
	public GameObject bossEnemy;

	public float spawnAreaWidth;
	public float spawnAreaHeight;

	public int numOfEnemiesX;
	public int numOfEnemiesY;

	public int numOfEnemiesX2;
	public int numOfEnemiesY2;

	public float secondWaveTime;
	private bool secondReady = true;
	private bool thirdReady = false;

	public float thirdWaveTime;
	private float startTime;
	private float totalTime;

	public GameBehavior gameScript;
	
	// Use this for initialization
	void Start () {
		startTime = Time.time;
		gameScript = Camera.main.GetComponent<GameBehavior>();
		EnemyAI bEnAI = basicEnemy.GetComponent<EnemyAI>();
		EnemyAI hEnAI = horEnemy.GetComponent<EnemyAI>();
		EnemyAI vEnAI = vertEnemy.GetComponent<EnemyAI>();
		for(int i = 0; i < numOfEnemiesX; i++){
			for(int j = 0; j < numOfEnemiesY; j++){
				Vector2 spawnPosition = transform.position;
				spawnPosition.x += i * (spawnAreaWidth/numOfEnemiesX);
				spawnPosition.y -= j * (spawnAreaHeight/numOfEnemiesY);
				if(i%2 == 0){
					Instantiate(basicEnemy,spawnPosition, bossEnemy.transform.rotation);
					float enShootSpeed = vEnAI.shootSpeed;
					vEnAI.setTime(Random.Range(0,  (int)enShootSpeed*10)/10);
				}
				else{
					Instantiate(basicEnemy,spawnPosition, bossEnemy.transform.rotation);
					float enShootSpeed = hEnAI.shootSpeed;
					hEnAI.setTime(Random.Range(0,  (int)enShootSpeed*10)/10);
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		totalTime = Time.time - startTime;
		if((totalTime > secondWaveTime || gameScript.enemiesKilled >= (numOfEnemiesX*numOfEnemiesY)) && secondReady){
			spawnSecond();
			secondReady = false;
			thirdReady = true;
		}
		if((totalTime > thirdWaveTime || gameScript.enemiesKilled >= (numOfEnemiesX*numOfEnemiesY) + (numOfEnemiesX2*numOfEnemiesY2)) && thirdReady){
			spawnThird();
		}
		
	}
	
	void spawnSecond () {
		MedEnemyAI mEnAI = medEnemy.GetComponent<MedEnemyAI>();
		for(int i = 0; i < numOfEnemiesX2; i++){
			for(int j = 0; j < numOfEnemiesY2; j++){
				Vector2 spawnPosition = transform.position;
				spawnPosition.x += i * (spawnAreaWidth/numOfEnemiesX2);
				spawnPosition.y -= j * (spawnAreaHeight/numOfEnemiesY2);
				//var clone : MedEnemy;
				Instantiate(medEnemy,spawnPosition, medEnemy.transform.rotation);
				float enShootSpeed = mEnAI.shootSpeed;
				mEnAI.setTime(Random.Range(0,  (int)enShootSpeed*10)/10);
				if(j%3 == 0){
					mEnAI.setDirection(0,0);
				}
				else if(j%3 == 1){
					mEnAI.setDirection(1,0);
				}
				else{
					mEnAI.setDirection(0,1);
				}
			}
		}
	}
	void spawnThird () {
		return;
	}
}