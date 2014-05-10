using UnityEngine;
using System.Collections;

/// <summary>
/// Handles simple bullet-creation logic
/// </summary>
public class SimpleBulletPattern : MonoBehaviour {
    public GameObject bullet;
    public float timeBetweenShots;
    public float startShootTime;

    private float time;

    void Start()
    {
        time = Time.time + timeBetweenShots + startShootTime;
    }
	
	// Update is called once per frame
	void Update () 
    {
        if (Time.time > time)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            time += timeBetweenShots;
        }
	}
}
