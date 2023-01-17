using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{

    [SerializeField] private float dropTime = 3f;
    private Rigidbody myRigidbody;
    private MeshRenderer meshRenderer;
    private bool hasDropped = false;


    private void Awake() 
    {
        myRigidbody = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if(!hasDropped && Time.time > dropTime)
        {
            hasDropped = true;
            meshRenderer.enabled = true;
            myRigidbody.useGravity = true;
        }
    }
}
