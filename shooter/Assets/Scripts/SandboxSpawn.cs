using UnityEngine;
using System.Collections;

/// <summary>
/// Controls the enemy spawn behavior of the sanbox scene
/// </summary>
public class SandboxSpawn : MonoBehaviour {

	public GameObject enemy1, enemy2, enemy3, enemy4;

	void Update() {
		if (Input.GetKey (KeyCode.Alpha1)) 
        {
            SpawnEnemy(enemy1);
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            SpawnEnemy(enemy2);
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            SpawnEnemy(enemy3);
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            SpawnEnemy(enemy4);
        }
	}

    private void SpawnEnemy(GameObject enemy)
    {
        foreach (GameObject existingEnemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            if (existingEnemy.Equals(enemy))
            {
                print("Name: " + existingEnemy.name);
                return;
            }
        }

        Vector3 spawnPoint = new Vector3(-1, 1, 0);
        Instantiate(enemy, spawnPoint, enemy.transform.rotation);
    }
}