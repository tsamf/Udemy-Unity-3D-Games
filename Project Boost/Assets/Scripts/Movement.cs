using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [Header("Speeds")]
    [SerializeField] float thrustSpeed = 1000f;
    [SerializeField] float rotationSpeed = 10f;
    [Header("Audio")]
    [SerializeField] AudioClip mainEngineSFX;
    [SerializeField][Range(0, 1)] float mainEngineSFXVolume = 1f;
    [Header("Particle Effects")]
    [SerializeField] ParticleSystem leftParticles;
    [SerializeField] ParticleSystem middleParticles;
    [SerializeField] ParticleSystem rightParticles;

    Rigidbody myRigidbody;
    AudioSource audioSource;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }

    }

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();

        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            StopRotating();
        }
    }

    private void StartThrusting()
    {
        myRigidbody.AddRelativeForce(Vector3.up * thrustSpeed * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngineSFX, mainEngineSFXVolume);
        }
        if (!middleParticles.isPlaying)
        {
            middleParticles.Play();
        }
    }

    private void StopThrusting()
    {
        audioSource.Stop();
        middleParticles.Stop();
    }

    private void RotateLeft()
    {
        ApplyRotation(rotationSpeed);

        if (!rightParticles.isPlaying)
        {
            rightParticles.Play();
        }
    }

    private void RotateRight()
    {
        ApplyRotation(-rotationSpeed);

        if (!leftParticles.isPlaying)
        {
            leftParticles.Play();
        }
    }

    private void StopRotating()
    {
        leftParticles.Stop();
        rightParticles.Stop();
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        myRigidbody.freezeRotation = true; // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        myRigidbody.freezeRotation = false; //unfreeze rotation so the physics system can take over
    }
}
