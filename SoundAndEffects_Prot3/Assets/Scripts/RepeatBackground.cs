using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth; //with to reset initial position of background
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position; //initial position of background
        repeatWidth = GetComponent<BoxCollider>().size.x / 2; //find midpoint in x direction of boxcollider width
    }

    // Update is called once per frame
    void Update()
    {
        //if the position of x (background) is less than the initial position minus half the width reset the position
        //simulates endless scrolling
        if (transform.position.x <= startPos.x - repeatWidth )
        {
            transform.position = startPos;
        }
    }
}
