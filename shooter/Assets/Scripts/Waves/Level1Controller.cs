using UnityEngine;
using System.Collections;

public class Level1Controller : MonoBehaviour, LevelController {
    public GameObject wave1EnemyA, wave1EnemyB, wave1EnemyC, wave1EnemyD;

    private int currentEnemyCount;
    private int currentWave;

    void Start()
    {
        currentEnemyCount = 4;
        currentWave = 1;

        StartWave1();
    }

    void Update()
    {
        
    }

    public void DecrementEnemyCount()
    {
        currentEnemyCount--;
    }

    private void StartWave1()
    {
        string pathName1 = wave1EnemyA.GetComponent<EnemyMovement>().pathName;
        string pathName2 = wave1EnemyB.GetComponent<EnemyMovement>().pathName;
        string pathName3 = wave1EnemyC.GetComponent<EnemyMovement>().pathName;
        string pathName4 = wave1EnemyD.GetComponent<EnemyMovement>().pathName;

        Instantiate(wave1EnemyA, iTweenPath.GetPath(pathName1)[0], wave1EnemyA.transform.rotation);
        Instantiate(wave1EnemyB, iTweenPath.GetPath(pathName2)[0], wave1EnemyB.transform.rotation);
        Instantiate(wave1EnemyC, iTweenPath.GetPath(pathName3)[0], wave1EnemyC.transform.rotation);
        Instantiate(wave1EnemyD, iTweenPath.GetPath(pathName4)[0], wave1EnemyD.transform.rotation);
    }
}
