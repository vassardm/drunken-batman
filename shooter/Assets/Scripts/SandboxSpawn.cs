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
            Instantiate(enemy1);
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            Instantiate(enemy2);
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            Instantiate(enemy3);
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            Instantiate(enemy4);
        }
	}
}