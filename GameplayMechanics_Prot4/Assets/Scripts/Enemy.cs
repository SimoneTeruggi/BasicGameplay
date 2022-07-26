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
    
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");

        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.isGameOver)
        {
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            enemyRb.AddForce(lookDirection * speed);

            if (gameObject.transform.position.y < lowerBound)
            {
                Destroy(gameObject);
            }
        }
        
    }
}
