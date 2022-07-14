using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    //Detect if projectiles enter animal collider
    private void OnTriggerEnter(Collider other)
    {
        //destroy both objects if projectiles hit
        Destroy(gameObject);
        Destroy(other.gameObject);
    }

}
