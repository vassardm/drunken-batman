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

	private bool secondReady = true;
	private bool thirdReady = false;
	private bool bossReady = false;

	public float bossWaveTime;
	public float thirdWaveTime;
	public float secondWaveTime;
	private float startTime;
	private float totalTime;

	private EnemyAI hEnAI;
	private EnemyAI vEnAI;

	private Vector3 bossSpawnPos;

	public GameBehavior gameScript;
	
	// Use this for initialization
	void Start () {
		totalTime = 0;
		startTime = Time.time;
		gameScript = Camera.main.GetComponent<GameBehavior>();
		hEnAI = horEnemy.GetComponent<EnemyAI>();
		vEnAI = vertEnemy.GetComponent<EnemyAI>();
		for(int i = 0; i < numOfEnemiesX; i++){
			for(int j = 0; j < numOfEnemiesY; j++){
				Vector2 spawnPosition = transform.position;
				spawnPosition.x += i * (spawnAreaWidth/numOfEnemiesX);
				spawnPosition.y -= j * (spawnAreaHeight/numOfEnemiesY);
				if(i%2 == 0){
					Instantiate(vertEnemy,spawnPosition, vertEnemy.transform.rotation);
					float enShootSpeed = vEnAI.shootSpeed;
					vEnAI.setTime(Random.Range(0,  (int)enShootSpeed*10)/10);
				}
				else{
					Instantiate(horEnemy,spawnPosition, horEnemy.transform.rotation);
					float enShootSpeed = hEnAI.shootSpeed;
					hEnAI.setTime(Random.Range(0,  (int)enShootSpeed*10)/10);
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		totalTime = Time.time - startTime;
		if ((totalTime > secondWaveTime || gameScript.enemiesKilled >= (numOfEnemiesX * numOfEnemiesY)) && secondReady) {
						print ("Spawning Wave 2 jfalsdjflasjdflasjfaldsjflsajdflaj");
						print (gameScript.enemiesKilled);
						spawnSecond ();
						secondReady = false;
						thirdReady = true;
				} else if ((totalTime > thirdWaveTime || gameScript.enemiesKilled >= ((numOfEnemiesX * numOfEnemiesY) + (numOfEnemiesX2 * numOfEnemiesY2))) && thirdReady) {
						print ("Spawning Wave 3 djfalsdjlfajdsflqjeorqpuweorq;lekjf;ladjzxmvlkdsoqweuroquroqu");
						print (gameScript.enemiesKilled);
						spawnThird ();
						thirdReady = false;
						bossReady = true;
				} else if ((totalTime > bossWaveTime || gameScript.enemiesKilled >= ((numOfEnemiesX * numOfEnemiesY) + 2 * (numOfEnemiesX2 * numOfEnemiesY2))) && bossReady) {
						spawnBoss ();
						bossReady = false;
				} else if (gameScript.bossKilled) {
						Application.LoadLevel("victoryScene");
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
				int rand = Random.Range(0,10);
				if(rand >= 4){
					Instantiate(medEnemy,spawnPosition, medEnemy.transform.rotation);
					float enShootSpeed = mEnAI.shootSpeed;
					mEnAI.setTime(Random.Range(0,  (int)enShootSpeed*10)/10);
				}
				else if(rand <= 2){
					Instantiate(horEnemy,spawnPosition, horEnemy.transform.rotation);
					float enShootSpeed = hEnAI.shootSpeed;
					hEnAI.setTime(Random.Range(0,  (int)enShootSpeed*10)/10);
				}
				else{
					Instantiate(vertEnemy,spawnPosition, vertEnemy.transform.rotation);
					float enShootSpeed = vEnAI.shootSpeed;
					vEnAI.setTime(Random.Range(0,  (int)enShootSpeed*10)/10);
				}
			}
		}
	}
	void spawnThird () {
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
			}
		}
	}

	void spawnBoss(){
		bossSpawnPos.x = -1;
		bossSpawnPos.y = 1;
		bossSpawnPos.z = 0;
		Instantiate(bossEnemy, bossSpawnPos, bossEnemy.transform.rotation);
	}
}