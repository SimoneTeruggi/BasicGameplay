using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 40.0f;
    // Update is called once per frame
    void Update()
    {
        //Move projectile forward continuously
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
