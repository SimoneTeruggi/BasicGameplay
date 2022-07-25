using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 15; //speed at which objects move
    public float leftBound = -5.0f; //left boundary after which gameobjects are destroyed
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>(); //reference to PlayerController
    }

    // Update is called once per frame
    void Update()
    {
        //if we are not in game over move objects to the left by speed
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        //if objects goes out of left boundary destroy it if it is an obstacle
        if (transform.position.x < leftBound && gameObject.transform.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
