using UnityEngine;

using System;
using System.Collections;

public class Level1Controller : MonoBehaviour 
{
    public GameObject wave1EnemyA, wave1EnemyB, wave1EnemyC, wave1EnemyD;
    public GameObject singlePathEnemy1, singlePathEnemy2;
    public GameObject boss;

    private int currentEnemyCount;
    private int currentWave;

    private const int WAVE1_COUNT = 4;
    private const int SINGLE_PATH_WAVE_COUNT = 15;


    void Start()
    {
        currentEnemyCount = 4;
        currentWave = 1;

        StartCoroutine(StartWave1());
    }

    void Update()
    {
        if (currentEnemyCount == 0) // Switch to next wave
        {
            switch (currentWave)
            {
                case 1:
                    currentWave++;
                    currentEnemyCount = SINGLE_PATH_WAVE_COUNT;
                    StartSinglePathWave(singlePathEnemy1, SINGLE_PATH_WAVE_COUNT);
                    break;
                case 2:
                    currentWave++;
                    currentEnemyCount = SINGLE_PATH_WAVE_COUNT;
                    StartSinglePathWave(singlePathEnemy2, SINGLE_PATH_WAVE_COUNT);
                    break;
                case 3:
                    currentEnemyCount = 1;
                    StartCoroutine(StartBoss());
                    break;
            }
        }
    }

    public void DecrementEnemyCount()
    {
        currentEnemyCount--;
    }

    private IEnumerator WaitAndSpawnEnemy(GameObject enemy, string pathName)
    {
        yield return new WaitForSeconds(1f);
        print("Spawn");
        Instantiate(enemy, iTweenPath.GetPath(pathName)[0], enemy.transform.rotation);
    }

    private IEnumerator StartWave1()
    {
        yield return new WaitForSeconds(1f);

        string pathName1 = wave1EnemyA.GetComponent<EnemyMovement>().pathName;
        string pathName2 = wave1EnemyB.GetComponent<EnemyMovement>().pathName;
        string pathName3 = wave1EnemyC.GetComponent<EnemyMovement>().pathName;
        string pathName4 = wave1EnemyD.GetComponent<EnemyMovement>().pathName;

        Instantiate(wave1EnemyA, iTweenPath.GetPath(pathName1)[0], wave1EnemyA.transform.rotation);
        Instantiate(wave1EnemyB, iTweenPath.GetPath(pathName2)[0], wave1EnemyB.transform.rotation);
        Instantiate(wave1EnemyC, iTweenPath.GetPath(pathName3)[0], wave1EnemyC.transform.rotation);
        Instantiate(wave1EnemyD, iTweenPath.GetPath(pathName4)[0], wave1EnemyD.transform.rotation);
    }

    /// <summary>
    /// Start a wave that has multiple enemies on a single path.
    /// </summary>
    /// <param name="enemy">The enemy to put on the path</param>
    private void StartSinglePathWave(GameObject enemy, int count)
    {
        string pathName = enemy.GetComponent<EnemyMovement>().pathName;
        StartCoroutine(SpawnSinglePathEnemies(enemy, pathName, count));
    }

    private IEnumerator SpawnSinglePathEnemies(GameObject enemy, string pathName, int count)
    {
        for (int i = 0; i < count; i++)
        {
            yield return new WaitForSeconds(1f);
            Instantiate(enemy, iTweenPath.GetPath(pathName)[0], enemy.transform.rotation);
        }
    }

    private IEnumerator StartBoss()
    {
        yield return new WaitForSeconds(1f);

        string pathName = boss.GetComponent<EnemyMovement>().pathName;
        Instantiate(boss, iTweenPath.GetPath(pathName)[0], boss.transform.rotation);
    }
}
