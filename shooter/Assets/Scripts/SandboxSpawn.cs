using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Controls the enemy spawn behavior of the sanbox scene
/// </summary>
public class SandboxSpawn : MonoBehaviour 
{
	public GameObject enemy1, enemy2, enemy3, enemy4, enemy5;
    public string pathName1, pathName2, pathName3, pathName4, pathName5;
    public GameBehavior gameScript;

	void Update() {
		if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            SpawnEnemy(enemy1, iTweenPath.GetPath(pathName1)[0]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SpawnEnemy(enemy2, iTweenPath.GetPath(pathName2)[0]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SpawnEnemy(enemy3, iTweenPath.GetPath(pathName3)[0]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SpawnEnemy(enemy4, iTweenPath.GetPath(pathName4)[0]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SpawnEnemy(enemy5, iTweenPath.GetPath(pathName5)[0]);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            gameScript.firePower += 10;
        }
	}

    private void SpawnEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        foreach (GameObject existingEnemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            if (existingEnemy.Equals(enemy))
            {
                print("Name: " + existingEnemy.name);
                return;
            }
        }

        Instantiate(enemy, spawnPoint, enemy.transform.rotation);
    }
}