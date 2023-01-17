using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{


    [SerializeField] float thrustSpeed = 1000f;
    [SerializeField] float rotationSpeed = 10f;
    Rigidbody myRigidbody;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {

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
            myRigidbody.AddRelativeForce(Vector3.up * thrustSpeed * Time.deltaTime);
        }
    }

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationSpeed);
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        myRigidbody.freezeRotation = true; // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        myRigidbody.freezeRotation = false; //unfreeze rotation so the physics system can take over
    }
}
