using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;

    public ParticleSystem explosionParticles;
    public ParticleSystem dirtParticles;

    public float jumpForce; // force applied to player to make it jump
    public float gravityModifier; //gravity modifier to render player heavier or lighter
    public bool isOnGround = true; //bool to check if player is on the ground
    public bool gameOver = false; //bool to check if player is in game over
    public bool doubleJumpUsed = false;
    public float doubleJumpForce;
    public bool doubleSpeed = false;

    public AudioClip jumpAudio;
    public AudioClip deathAudio;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        Physics.gravity *= gravityModifier; //modify gravity by gravitymodifier
        
    }

    // Update is called once per frame
    void Update()
    {
        //make player jump when spacebar is pressed and player is on ground, prevent subsequent jumps
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticles.Stop();
            playerAudio.PlayOneShot(jumpAudio, 1.0f);

            doubleJumpUsed = false;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !isOnGround && !doubleJumpUsed)
        {
            doubleJumpUsed = true;
            playerRb.AddForce(Vector3.up * doubleJumpForce, ForceMode.Impulse);
            playerAnim.Play("Running_Jump", 3, 0f);
            playerAudio.PlayOneShot(jumpAudio, 1.0f);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            doubleSpeed = true;
            playerAnim.SetFloat("Speed_Multiplier", 2.0f);
        }
        else if (doubleSpeed)
        {
            doubleSpeed = false;
            playerAnim.SetFloat("Speed_Multiplier", 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if player hit ground he can jump again
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticles.Play();
        }
        //else if player hit obstacle goes to game over
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticles.Play();
            dirtParticles.Stop();
            playerAudio.PlayOneShot(deathAudio, 1.0f);
        }
    }
}
