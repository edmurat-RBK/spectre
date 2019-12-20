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
    public bool listening = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        movementComponent = GetComponent<EnemyMovement>();
        template = GameObject.Find("MusicScoreTemplate").GetComponent<MusicScoreTemplate>();

        musicScore = template.PickOne();
        audioSource.clip = musicScore.audio;
        audioSource.Play();

        switch(musicScore.musicScore.Count)
        {
            case 3:
                Debug.Log(musicScore.musicScore[0] + " " + musicScore.musicScore[1] + " " + musicScore.musicScore[2]);
                break;

            case 4:
                Debug.Log(musicScore.musicScore[0] + " " + musicScore.musicScore[1] + " " + musicScore.musicScore[2] + " " + musicScore.musicScore[3]);
                break;

            case 5:
                Debug.Log(musicScore.musicScore[0] + " " + musicScore.musicScore[1] + " " + musicScore.musicScore[2] + " " + musicScore.musicScore[3] + " " + musicScore.musicScore[4]);
                break;
        }
    }

    private void Update()
    {
        movementComponent.speed = movementComponent.baseSpeed + (movementComponent.scaleSpeed * gameManager.level);

        if(listening)
        {
            Kill();
        }
    }

    public void Hit()
    {
        gameObject.GetComponentInChildren<MeshRenderer>().material.color = new Color(255f, 255f, 255f, 192f);

        listening = true;
    }

    public void Kill()
    {
        bool note1, note2, note3, note4, note5;

        switch(musicScore.musicScore.Count)
        {
            case 3:
                note1 = (musicScore.musicScore[0] == gameManager.lastInput[2]);
                note2 = (musicScore.musicScore[1] == gameManager.lastInput[3]);
                note3 = (musicScore.musicScore[2] == gameManager.lastInput[4]);
                note4 = true;
                note5 = true;
                break;

            case 4:
                note1 = (musicScore.musicScore[0] == gameManager.lastInput[1]);
                note2 = (musicScore.musicScore[1] == gameManager.lastInput[2]);
                note3 = (musicScore.musicScore[2] == gameManager.lastInput[3]);
                note4 = (musicScore.musicScore[3] == gameManager.lastInput[4]);
                note5 = true;
                break;

            case 5:
                note1 = (musicScore.musicScore[0] == gameManager.lastInput[0]);
                note2 = (musicScore.musicScore[1] == gameManager.lastInput[1]);
                note3 = (musicScore.musicScore[2] == gameManager.lastInput[2]);
                note4 = (musicScore.musicScore[3] == gameManager.lastInput[3]);
                note5 = (musicScore.musicScore[4] == gameManager.lastInput[4]);
                break;

            default:
                note1 = false;
                note2 = false;
                note3 = false;
                note4 = false;
                note5 = false;
                break;
        }

        if(note1 && note2 && note3 && note4 && note5)
        {
            gameManager.enemyAlive = false;
            Destroy(gameObject);
        }
    }
}
