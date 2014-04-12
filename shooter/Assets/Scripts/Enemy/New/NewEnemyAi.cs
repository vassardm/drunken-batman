using UnityEngine;
using System.Collections;

public class NewEnemyAI : MonoBehaviour 
{
    public int health;
    public int speed;

    public RegularEnemyRewards rewards;

    public GameBehavior GameScript { get; set; }

	// Use this for initialization
	void Start () {
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
            rewards.DropRewards(GameScript);
        }
    }

    #region Movement

    private Vector3[] GetRelativePath(string pathName, Vector3 relativePoint)
    {
        Vector3[] path = iTweenPath.GetPath (pathName);
        Vector3[] result = new Vector3[path.Length];
        for (int i =0; i < path.Length; i++) 
        {
            result[i] = relativePoint + path[i];
        }

        return result;
    }

    #endregion
}
