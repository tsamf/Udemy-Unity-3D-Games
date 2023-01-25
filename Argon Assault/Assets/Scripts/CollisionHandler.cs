using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem explosion;
    
    BoxCollider boxCollider;
    MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        startDying();
    }

    private void startDying()
    {
        StartCoroutine(Die());
    }

    IEnumerator Die()
    {
        explosion.Play();
        meshRenderer.enabled = false;
        GetComponent<PlayerMovement>().enabled = false;
        boxCollider.enabled = false;
        yield return new WaitForSeconds(loadDelay);
        reloadLevel();
    }

    private void reloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
