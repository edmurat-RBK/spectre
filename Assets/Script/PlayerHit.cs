using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public AudioClip hitSound;
    private AudioSource audioSource;
    private GameManager gameManager;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        audioSource.PlayOneShot(hitSound);

        gameManager.miss += gameManager.normalEnemyMissIncrement;
        gameManager.enemyAlive = false;

        Destroy(other.gameObject);
    }
}
