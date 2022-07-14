using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float topBound = 30.0f;
    public float lowerBound = -10.0f;
    // Start is called before the first frame update
    void Update()
    {
        //if projetiles reaces upper screen boud destroies the gameObject (avoid having tooooo many useless gameObjects in the scene)
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        //if animal reaches lower scree bound destroies it (avoid having tooooo many useless gameObjects in the scene)
        else if (transform.position.z < lowerBound)
        {
            Debug.Log("GameOver");
            Destroy(gameObject);
        }
    }
}
