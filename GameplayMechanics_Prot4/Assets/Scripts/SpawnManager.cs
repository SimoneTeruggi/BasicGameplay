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
            SpawnEnemyWave(waveNumber);
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

    void SpawnEnemyWave(int enemyToSpawn)
    {
        for (int i = 0; i < enemyToSpawn; i++)
        {
            int randomIndex = Random.Range(0, enemyPrefabs.Length);

            Instantiate(enemyPrefabs[randomIndex], GenerateSpawnPosition(), enemyPrefabs[randomIndex].transform.rotation);
        }
    }
}
