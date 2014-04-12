using UnityEngine;
using System.Collections;

/// <summary>
/// Controls the enemy spawn behavior of the sanbox scene
/// </summary>
public class SandboxSpawn : MonoBehaviour 
{
	public GameObject enemy1, enemy2, enemy3, enemy4, enemy5;
    public GameBehavior gameScript;

	void Update() {
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
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SpawnEnemy(enemy5);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            gameScript.firePower += 10;
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