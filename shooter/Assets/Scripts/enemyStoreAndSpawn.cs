using UnityEngine;
using System.Collections;


public class enemyStoreAndSpawn : MonoBehaviour {

	public GameObject minion;

	public GameBehavior gameScript;
	public ScoreStorage scoreStorage;

	public ArrayList enemyStore;

	void Start() {
		enemyStore = new ArrayList ();
		addOneSingleEnemy (0);
		addOneSingleEnemy (1);
		addOneSingleEnemy (2);
		addOneSingleEnemy (3);
	}

	void Update() {
		int collectorIndex = -1;
		string getStatus = "Default key input";
		if (Input.GetKey (KeyCode.Keypad0)) {
			/*
			collectorIndex = 0;
			attachEnemyAItoGameObject(minion);
			launchEnemyIntoScene (collectorIndex);
			getStatus = "I have collected the key 0";
			print (getStatus);
			print ("I have launched an enemy.");
			*/
		}
		else {
			print (getStatus);
		}
		
	}

	public ArrayList getEnemyStore() {
		return enemyStore;
	}

	public ArrayList addOneSingleEnemy(int enemyObject) {
		enemyStore.Add (enemyObject);
		return enemyStore;
	}

	public int launchEnemyIntoScene(int enemyIndex) {
			int enemy = enemyStore.IndexOf (enemyIndex);
			return enemy;
		}

	public void clearStore() {
		enemyStore.Clear ();
	}

	public void attachEnemyAItoGameObject(GameObject minion) {
		minion.GetComponent<EnemyAI> ();
	}

}