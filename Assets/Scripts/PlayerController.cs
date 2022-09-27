using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _playerRb;
    private Animator _playerAnimator;
    private AudioSource _playerAudio;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    
    public float jumpForce = 10.0f;

    public float gravityModifier;

    public bool isOnGround = true;

    public bool gameOver;

    // Start is called before the first frame update
    /**
     * 
     */
    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        _playerAnimator = GetComponent<Animator>();
        _playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            _playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }

        _playerAnimator.SetTrigger("Jump_trig");
        dirtParticle.Stop();
        _playerAudio.PlayOneShot(jumpSound, 1.0f);
    }

    /**
 * @function OnCollisionEnter
 * Manages Collision and display custom effects
 */
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            _playerAnimator.SetBool("Death_b", true);
            _playerAnimator.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            _playerAudio.PlayOneShot(crashSound, 1.0f);
            Debug.Log("Game Over!");
        }
    }
}