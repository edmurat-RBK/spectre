using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Spawncircle[] spawnCircleArray;
    private AudioSource audioSource;

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

    [Header("Spawning parameters")]
    private float spawnTime;
    public float spawnMaxTime;
    public float spawnMinRange;
    public float spawnMaxRange;
    [Space(5)]
    public float baseDistance;
    public float scaleDistance;
    public float spawnDistance;

    public int numberGhost;
    private void Start()
    {
        level = 1;
        miss = 0;

        audioSource = GetComponent<AudioSource>();

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
    }

    public void PlayAudioSource()
    {
        audioSource.Play();
    }
}
