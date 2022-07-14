using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 12;
    private float spawnPosz = 20;

    private float spawnDelay  = 1.0f;
    private float spawnInterval = 1.0f;

    private void Start()
    {
        //spawn animals at random locations at defined intervals of times
        InvokeRepeating("SpawnRandomAnimals", spawnDelay, spawnInterval);
    }

    private void SpawnRandomAnimals()
    {
        //casual spawnposition
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosz);

        //random animal index to spawn
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        //spawna animalIndex at spawnPos (we use prefab rotation)
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
}
