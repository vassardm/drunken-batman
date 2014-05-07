using UnityEngine;
using System.Collections;

public class NewEnemyAI : MonoBehaviour 
{
    public int health;

    private RegularEnemyRewards rewards;
    private Level1Controller controller;
    private GameBehavior GameScript { get; set; }

	// Use this for initialization
	void Start () {
        rewards = Camera.main.GetComponent<RegularEnemyRewards>();
        controller = Camera.main.GetComponent<Level1Controller>();
        GameScript = Camera.main.GetComponent<GameBehavior>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("PlayerBullet"))
        {
            health--;
            BulletAI bulletAI = other.GetComponent<BulletAI>();
            bulletAI.bulletDestroy();
        }
        else if (other.tag.Equals("Player"))
        {
            health--;
        }

        if (health < 1)
        {
            Destroy(gameObject);
            GameScript.enemiesKilled++;
            rewards.DropRewards(GameScript, gameObject);
            controller.DecrementEnemyCount();
        }
    }
}
