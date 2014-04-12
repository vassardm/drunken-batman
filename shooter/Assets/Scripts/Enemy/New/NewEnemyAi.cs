using UnityEngine;
using System.Collections;

public class NewEnemyAI : MonoBehaviour 
{
    public int hitpoints;

    public GameBehavior GameScript { get; set; }
    public IEnemyMovement Movement { get; set; }
    public IEnemyRewards Rewards { get; set; }

	// Use this for initialization
	void Start () {
        GameScript = Camera.main.GetComponent<GameBehavior>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
