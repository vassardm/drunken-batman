using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Controls the enemy spawn behavior of the sanbox scene
/// </summary>
public class SandboxSpawn : MonoBehaviour 
{

	public GameObject enemy1, enemy2, enemy3, enemy4;

	void Update() 
    {
		if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            SpawnEnemy(enemy1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SpawnEnemy(enemy2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SpawnEnemy(enemy3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SpawnEnemy(enemy4);
        }
	}

    private void SpawnEnemy(GameObject enemy)
    {
            Vector3 spawnPoint = new Vector3(-1.5f, 2, 0);
            Instantiate(enemy, spawnPoint, enemy.transform.rotation);
    }
}