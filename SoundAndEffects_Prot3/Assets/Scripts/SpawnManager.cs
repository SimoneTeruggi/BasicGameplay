using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; //reference to obstacle to spawn
    private PlayerController playerControllerScript;
    private Vector3 spawnPos = new Vector3(20, 0, 0);
    private float startDelay = 2.0f; //time after which to start spawning obstacles
    private float repeatDelay = 2.0f; 

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatDelay); //spawn obstacles every repeatDelay seconds
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnObstacle()
    {
        //spawn obstacles only if not in game over
        if (playerControllerScript.gameOver == false)
        {
            int prefabSpawnIndex = Random.Range(0, obstaclePrefabs.Length);
            Instantiate(obstaclePrefabs[prefabSpawnIndex], spawnPos, obstaclePrefabs[prefabSpawnIndex].transform.rotation);
        }
        
    }
}
