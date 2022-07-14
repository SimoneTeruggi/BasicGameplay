using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    public float xRange = 10.0f;

    public GameObject projectilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // forbids the player to go out of screen (left)
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        // forbids the player to go out of screen (right)
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        //get horizontal input axis (arrows & A, D keys)
        horizontalInput = Input.GetAxis("Horizontal");
        //translate player horizontally Time.deltaTime makes sure that update based on time and not on frames
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        //if Spacebar is pressed shot projectile. We use prefab rotation.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
