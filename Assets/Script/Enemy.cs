using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private AudioSource audioSource;
    private GameManager gameManager;
    private EnemyMovement movementComponent;
    private MusicScoreTemplate template;

    public MusicScore musicScore;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        movementComponent = GetComponent<EnemyMovement>();
        template = GameObject.Find("MusicScoreTemplate").GetComponent<MusicScoreTemplate>();

        musicScore = template.PickOne();
        audioSource.clip = musicScore.audio;
        audioSource.Play();
    }

    private void Update()
    {
        movementComponent.speed = movementComponent.baseSpeed + (movementComponent.scaleSpeed * gameManager.level);
    }

    public void Hit()
    {
        // gameObject.GetComponentInChildren<MeshRenderer>().material.color = new Color(255f, 255f, 255f, 200f);
        gameObject.GetComponentInChildren<MeshRenderer>().material.color = new Color(255f, 255f, 255f, 192f);
    }

}
