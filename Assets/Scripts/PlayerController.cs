using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _playerRb;
    private KeyCode _jumpKey = KeyCode.Space;
    private bool _isOnGround = true;
    
    private Animator _playerAnimator;
    private AudioSource _playerAudio;
    
    [HideInInspector] public bool gameOver = false;

    [SerializeField] private float jumpForce;
    [SerializeField] private float gravityMod;

    [SerializeField] private ParticleSystem dirtParticle;
    [SerializeField] private ParticleSystem explosionParticle;

    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip crashSound;
    
    void Start()
    {
        _playerAnimator = GetComponent<Animator>();
        _playerRb = GetComponent<Rigidbody>();
        _playerAudio = GetComponent<AudioSource>();
        
        Physics.gravity *= gravityMod;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(_jumpKey) && _isOnGround && !gameOver)
        {
            dirtParticle.Stop();
            
            _playerAnimator.SetTrigger("Jump_trig");
            _playerRb.AddForce(Vector3.up*jumpForce, ForceMode.Impulse);
            _playerAudio.PlayOneShot(jumpSound, 1f);
            
            _isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        _isOnGround = other.gameObject.CompareTag("Ground");
        gameOver = other.gameObject.CompareTag("Obstacle");

        if (other.gameObject.CompareTag("Obstacle"))
        {
            explosionParticle.Play();
            dirtParticle.Stop();
            
            _playerAnimator.SetBool("Death_b", true);
            _playerAnimator.SetInteger("DeathType_int", 1);
            _playerAudio.PlayOneShot(crashSound, 1f);
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            dirtParticle.Play();
        }
    }
}
