using UnityEngine;
using System.Collections;

public class DestroyInvisible : MonoBehaviour {

	void OnBecameInvisible() 
	{
		Destroy(gameObject);
	}

}
