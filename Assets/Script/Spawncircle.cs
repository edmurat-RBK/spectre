using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Spawncircle : MonoBehaviour
{
    private GameManager gameManager;
    private GameObject camera;
    public float spawnRadius;

    private float moveTowardX;
    private float moveTowardZ;
    private float replacementSpeed;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        camera = GameObject.FindGameObjectWithTag("MainCamera");

        replacementSpeed = 0.005f;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, camera.transform.position, replacementSpeed * Time.deltaTime);

        /*
        if (transform.position.x < moveTowardX)
        {
            transform.position = new Vector3(transform.position.x + replacementSpeed, transform.position.y, transform.position.z);
            if (transform.position.x >= moveTowardX)
            {
                transform.position = new Vector3(moveTowardX, transform.position.y, moveTowardZ);
            }
        }
        else if (transform.position.x > moveTowardX)
        {
            transform.position = new Vector3(transform.position.x - replacementSpeed, transform.position.y, transform.position.z);
            if (transform.position.x <= moveTowardX)
            {
                transform.position = new Vector3(moveTowardX, transform.position.y, moveTowardZ);
            }
        }

        if (transform.position.z < moveTowardZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + replacementSpeed);
            if (transform.position.z >= moveTowardZ)
            {
                transform.position = new Vector3(moveTowardX, transform.position.y, moveTowardZ);
            }
        }
        else if (transform.position.z > moveTowardZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - replacementSpeed);
            if (transform.position.z <= moveTowardZ)
            {
                transform.position = new Vector3(moveTowardX, transform.position.y, moveTowardZ);
            }
        }
        */
    }

    public void SpawnEnemy()
    {
        float rad = Mathf.Deg2Rad * Random.Range(0f, 360f);

        float xPos = Mathf.Cos(rad) * spawnRadius;
        float zPos = Mathf.Sin(rad) * spawnRadius;

        Instantiate(gameManager.enemy, new Vector3(xPos,transform.position.y,zPos), Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        Handles.color = Color.blue;
        Handles.DrawWireDisc(transform.position, Vector3.up,spawnRadius);
    }
}
