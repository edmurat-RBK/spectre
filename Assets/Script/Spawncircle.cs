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
    public float replacementSpeed;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(camera.transform.position.x, transform.position.y, camera.transform.position.z), replacementSpeed * Time.deltaTime);

        /*
        if (transform.position.x < moveTowardX)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(moveTowardX, transform.position.y, moveTowardZ), replacementSpeed);
            if (transform.position.x >= moveTowardX)
            {
                transform.position = new Vector3(moveTowardX, transform.position.y, moveTowardZ);
            }
        }
        else if (transform.position.x > moveTowardX)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x - replacementSpeed, transform.position.y, transform.position.z), replacementSpeed);
            if (transform.position.x <= moveTowardX)
            {
                transform.position = new Vector3(moveTowardX, transform.position.y, moveTowardZ);
            }
        }

        if (transform.position.z < moveTowardZ)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z + replacementSpeed), replacementSpeed);
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
        //Handles.color = Color.blue;
        //Handles.DrawWireDisc(transform.position, Vector3.up,spawnRadius);
    }
}
