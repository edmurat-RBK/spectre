using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Spawncircle[] spawnCircleArray;
    private AudioSource[] audioSource;
    private GameObject player;

    [Header("Game")]
    public int level;

    [Header("Enemy")]
    public GameObject enemy;
    public bool enemyAlive;
    public int normalEnemyMissIncrement;
    public int eliteEnemyMissIncrement;

    [Header("Player statistics")]
    public int maxMiss;
    public int miss;
    public bool gameOver = false;
    public GameObject gameOverPrefab;
    private GameObject gameOverSpawned;

    [Header("Spawning parameters")]
    private float spawnTime;
    public float spawnMaxTime;
    public float spawnMinRange;
    public float spawnMaxRange;
    [Space(5)]
    public float baseDistance;
    public float scaleDistance;
    public float spawnDistance;

    [Header("Audio")]
    public AudioClip backgroundNormal;
    public AudioClip backgroundGhost;

    public List<Note> lastInput;

    private void Start()
    {
        level = 1;
        miss = 0;

        audioSource = GetComponents<AudioSource>();
        audioSource[0].clip = backgroundNormal;
        audioSource[1].clip = backgroundGhost;
        audioSource[0].Play();
        audioSource[1].Play();
        audioSource[1].mute = true;

        lastInput = new List<Note>(6);

        player = GameObject.FindGameObjectWithTag("MainCamera");

        spawnCircleArray = new Spawncircle[3];
        spawnCircleArray[0] = GameObject.Find("Spawn Circle L-1").GetComponent<Spawncircle>();
        spawnCircleArray[1] = GameObject.Find("Spawn Circle L0").GetComponent<Spawncircle>();
        spawnCircleArray[2] = GameObject.Find("Spawn Circle L1").GetComponent<Spawncircle>();

        spawnTime = spawnMaxTime + Random.Range(spawnMinRange, spawnMaxRange);
    }

    private void Update()
    {
        spawnDistance = baseDistance + (scaleDistance * level);

        if(!enemyAlive)
        {
            // Decrease timer
            spawnTime -= Time.deltaTime;

            // When timer hit 0
            if (spawnTime <= 0)
            {
                // Spawn an enemy
                spawnCircleArray[Random.Range(0, 3)].SpawnEnemy();
                enemyAlive = true;

                // Reset spawn timer
                spawnTime = spawnMaxTime + Random.Range(spawnMinRange, spawnMaxRange);
            }
        }

        // Check game over
        if(miss >= maxMiss && !gameOver)
        {
            gameOver = true;
            GameOver();
        }
        else if(gameOver)
        {
            gameOverSpawned.transform.position = player.transform.TransformDirection(Vector3.forward * 2);
        }

        // Music
        if(enemyAlive)
        {
            if (!audioSource[1].isPlaying)
            {
                audioSource[0].mute = true;
                audioSource[1].mute = false;
            }
        }
        else
        {
            if (!audioSource[0].isPlaying)
            {
                audioSource[1].mute = true;
                audioSource[0].mute = false;
            }
        }

        Debug.Log(lastInput[0] + " " + lastInput[1] + " " + lastInput[2] + " " + lastInput[3] + " " + lastInput[4]);
        // Inputs
        if(lastInput.Count > 5)
        {
            lastInput.RemoveAt(0);
        }
    }

    private void GameOver()
    {
        gameOverSpawned = Instantiate(gameOverPrefab, new Vector3(0f, 0f, 0f), new Quaternion(0f, 0f, 0f, 0f));
    }
}
