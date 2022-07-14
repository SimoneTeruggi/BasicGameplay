using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float spamInterval = 3.0f;
    private float timeKeyAllowed;
    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog (check that 3 sec passed before allowing to press again)
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > timeKeyAllowed)
            {
                float timeFromKeyPressed = Time.time;
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                timeKeyAllowed = Time.time + spamInterval;
            }
        }
}
