using UnityEngine;
using System.Collections;

public class WaveGenerator : MonoBehaviour {

	IWave[] waves;

	// Use this for initialization
	void Start () {
		waves = new IWave[1];
		waves [0] = new Wave1();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
