using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float baseSpeed;
    public float scaleSpeed;
    public float speed;

    private Vector3 direction;
    private GameObject camera;
    

    private void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void Update()
    {
        direction = (camera.transform.position - transform.position).normalized;

        transform.position += direction * speed * Time.deltaTime;
    }
}
