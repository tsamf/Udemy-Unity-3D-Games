using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] int scorePerHit; 
    [SerializeField] int hitPoints = 3;

    [Header("Sound Effects")]
    [SerializeField] AudioClip explosionSFX;
    [SerializeField][Range(0,1)] float explosionSFXVolume = 1f; 

    ScoreBoard scoreBoard;
    Rigidbody myRigidBody;
    GameObject parentGameObject;


    private void Awake() {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        parentGameObject = GameObject.FindGameObjectWithTag("SpawnAtRuntime");
    }

    private void Start()
    {
        AddRigidbody();
    }

    private void AddRigidbody()
    {
        myRigidBody = gameObject.AddComponent<Rigidbody>();
        myRigidBody.useGravity = false;
    }

    // Start is called before the first frame update
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();

        if(hitPoints < 1)
        {
            KillEnemy();
        }
    }

    private void ProcessHit()
    {   
        Instantiate(hitVFX, transform.position, Quaternion.identity, parentGameObject.transform);
        hitPoints--;
        scoreBoard.IncreaseScore(scorePerHit);
    }

    private void KillEnemy()
    {
        AudioSource.PlayClipAtPoint(explosionSFX,Camera.main.transform.position, explosionSFXVolume);
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity, parentGameObject.transform);
        Destroy(gameObject);
    }
}
