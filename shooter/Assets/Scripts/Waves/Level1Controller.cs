using UnityEngine;

using System;
using System.Collections;

public class Level1Controller : MonoBehaviour 
{
    public GameObject wave1EnemyA, wave1EnemyB, wave1EnemyC, wave1EnemyD;
    public GameObject wave2Enemy;

    private int currentEnemyCount;
    private int currentWave;

    private const int WAVE1_COUNT = 4;
    private const int WAVE2_COUNT = 15;

    void Start()
    {
        currentEnemyCount = 4;
        currentWave = 1;

        StartCoroutine(WaitAndStartWave(() => StartWave1()));
    }

    void Update()
    {
        if (currentEnemyCount == 0) // Switch to next wave
        {
            switch (currentWave)
            {
                case 1:
                    currentWave++;
                    currentEnemyCount = WAVE2_COUNT;
                    StartCoroutine(WaitAndStartWave(() 
                        => StartSinglePathWave(wave2Enemy, WAVE2_COUNT)));
                    break;
            }
        }
    }

    public void DecrementEnemyCount()
    {
        print("Decrementing count");
        currentEnemyCount--;
    }

    /// <summary>
    /// Wait for a bit then spawn the given wave.
    /// </summary>
    /// <param name="startWaveMethod">The method that spawns a certain wave.</param>
    /// <returns>The IEnumerator necessary for the caller StartCoroutine</returns>
    private IEnumerator WaitAndStartWave(Action startWaveMethod)
    {
        yield return new WaitForSeconds(1.5f);
        startWaveMethod();
    }

    private IEnumerator WaitAndSpawnEnemy(GameObject enemy, string pathName)
    {
        yield return new WaitForSeconds(1f);
        Instantiate(enemy, iTweenPath.GetPath(pathName)[0], enemy.transform.rotation);
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

    /// <summary>
    /// Start a wave that has multiple enemies on a single path.
    /// </summary>
    /// <param name="enemy">The enemy to put on the path</param>
    private void StartSinglePathWave(GameObject enemy, int count)
    {
        string pathName = enemy.GetComponent<EnemyMovement>().pathName;

        for (int i = 0; i < count; i++)
        {
            StartCoroutine(WaitAndSpawnEnemy(wave2Enemy, pathName));
        }
    }
}
