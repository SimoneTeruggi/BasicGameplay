using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject[] powerUps;
    private float spawnRange = 9;

    PlayerController playerControllerScript;

    public int enemycount = 0;
    public int waveNumber = 1;

    public GameObject bossPrefab;
    public GameObject[] miniEnemyPrefab;
    public int bossRound;

    // Start is called before the first frame update
    void Start()
    {
        int randomPowerUp = Random.Range(0, powerUps.Length);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        SpawnEnemyWave(waveNumber);
        Instantiate(powerUps[randomPowerUp], GenerateSpawnPosition(), powerUps[randomPowerUp].transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemycount = FindObjectsOfType<Enemy>().Length;

        if (enemycount == 0 && !playerControllerScript.isGameOver)
        {
            waveNumber++;

            //Spawn a boss every x number of waves
            if (waveNumber % bossRound == 0)
            {
                SpawnBossWave(waveNumber);
            }
            else
            {
                SpawnEnemyWave(waveNumber);
            }
            
            int randomPowerUp = Random.Range(0, powerUps.Length);
            Instantiate(powerUps[randomPowerUp], GenerateSpawnPosition(), powerUps[randomPowerUp].transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }

    void SpawnBossWave(int currentRound)
    {
        int miniEnemysToSpawn;
        //We don't want to divide by 0!
        if (bossRound != 0)
        {
            miniEnemysToSpawn = currentRound / bossRound;
        }
        else
        {
            miniEnemysToSpawn = 1;
        }

        var boss = Instantiate(bossPrefab, GenerateSpawnPosition(), bossPrefab.transform.rotation);
        boss.GetComponent<Enemy>().miniEnemySpawnCount = miniEnemysToSpawn;
    }

    public void SpawnMiniEnemy(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            int randomMini = Random.Range(0, miniEnemyPrefab.Length);
            Instantiate(miniEnemyPrefab[randomMini], GenerateSpawnPosition(), miniEnemyPrefab[randomMini].transform.rotation);

        }
    }

    void SpawnEnemyWave(int enemyToSpawn)
    {
        for (int i = 0; i < enemyToSpawn; i++)
        {
            int randomIndex = Random.Range(0, enemyPrefabs.Length);

            Instantiate(enemyPrefabs[randomIndex], GenerateSpawnPosition(), enemyPrefabs[randomIndex].transform.rotation);
        }
    }
}
