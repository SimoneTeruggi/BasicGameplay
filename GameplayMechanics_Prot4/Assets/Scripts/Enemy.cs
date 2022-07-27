using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 0.7f;

    private Rigidbody enemyRb;
    private GameObject player;

    private PlayerController playerControllerScript;

    public float lowerBound = -10;

    public bool isBoss = false;

    public float spawnInterval;
    private float nextSpawn;

    public int miniEnemySpawnCount;

    private SpawnManager spawnManager;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");

        if (isBoss)
        {
            spawnManager = FindObjectOfType<SpawnManager>();
        }

        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.isGameOver)
        {
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            enemyRb.AddForce(lookDirection * speed);

            if (isBoss)
            {
                if (Time.time > nextSpawn)
                {
                    nextSpawn = Time.time + spawnInterval;
                    spawnManager.SpawnMiniEnemy(miniEnemySpawnCount);
                }
            }

        }

        if (gameObject.transform.position.y < lowerBound)
        {
            Destroy(gameObject);
        }

    }
}
