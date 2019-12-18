using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private AudioSource audioSource;
    private GameManager gameManager;
    private EnemyMovement movementComponent;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        movementComponent = GetComponent<EnemyMovement>();
        audioSource.Play();
    }

    private void Update()
    {
        movementComponent.speed = movementComponent.baseSpeed + (movementComponent.scaleSpeed * gameManager.level);
    }

    public void Hit()
    {
        gameManager.enemyAlive = false;
        Destroy(gameObject);
    }

}
