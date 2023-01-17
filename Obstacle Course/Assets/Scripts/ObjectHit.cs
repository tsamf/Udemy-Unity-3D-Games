using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{

    MeshRenderer myMeshRenderer;

    private void Awake() {
        myMeshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Player")
        {
            myMeshRenderer.material.color = Color.red;
            gameObject.tag = "Hit";
        }
    }
}
