using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerUp;
    private float spawnRange = 9;

    PlayerController playerControllerScript;

    public int enemycount = 0;
    public int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        SpawnEnemyWave(waveNumber);
        Instantiate(powerUp, GenerateSpawnPosition(), powerUp.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemycount = FindObjectsOfType<Enemy>().Length;
        if (enemycount == 0 && !playerControllerScript.isGameOver)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerUp, GenerateSpawnPosition(), powerUp.transform.rotation);
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
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
}
