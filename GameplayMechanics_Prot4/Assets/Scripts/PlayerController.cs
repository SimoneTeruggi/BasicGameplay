using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject focalPoint;
    public GameObject powerUpIndicator;

    public float speed = 5.0f;
    public bool hasPowerUp;
    public float powerUpStrenght = 5.0f;
    public float powerUpDuration = 5.0f;
    public bool isGameOver = false;
    public float lowerBound = -10;

    private Rigidbody playerRb;
    // Start is called before the first frame update
    void Start()
    {
        focalPoint = GameObject.Find("FocalPoint");
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        powerUpIndicator.transform.position = transform.position + new Vector3 (0, -0.5f, 0);
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);

        if (transform.position.y < lowerBound)
        {
            isGameOver = true;
            Destroy(gameObject);
            Debug.Log("GAME OVER");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            powerUpIndicator.SetActive(true);
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(powerUpDuration);
        powerUpIndicator.SetActive(false);
        hasPowerUp = false;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            Debug.Log("Collided with: " + collision.gameObject.name + " with PowerUp set to: " + hasPowerUp);
            enemyRigidbody.AddForce(awayFromPlayer * powerUpStrenght, ForceMode.Impulse);
        }
    }
}
