using UnityEngine;
using System.Collections;

abstract public class IWave : MonoBehaviour {

	// Use this for initialization
	abstract public void Start ();
	
	// Update is called once per frame
	abstract public void Update ();

	abstract public bool isFinished();
}
