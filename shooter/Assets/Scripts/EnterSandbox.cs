using UnityEngine;
using System.Collections;

/// <summary>
/// Loads the Sanbox scene
/// </summary>
public class EnterSandbox : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.BackQuote))
        {
            Application.LoadLevel("sandbox");
        }
	}
}
