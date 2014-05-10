using UnityEngine;
using System.Collections;

/// <summary>
/// Handles simple bullet-creation logic
/// </summary>
public class SimpleBulletPattern : MonoBehaviour {
    public GameObject bullet;
    public float timeBetweenShots;
    public float startShootTime;

    private THorseSystemMechanics th;

    private float time;

    void Start()
    {
        th = Camera.main.GetComponent<THorseSystemMechanics>();

        time = Time.time + (timeBetweenShots + th.GetModifier(2)) + (startShootTime + th.GetModifier(1));
    }
	
	// Update is called once per frame
	void Update () 
    {
        if (Time.time > time)
        {
            int counter = 0;
            print(counter + 1 + "I am firing!!!!!!");
            Instantiate(bullet, transform.position, transform.rotation);
            time += (timeBetweenShots + th.GetModifier(2));
        }
	}
}
