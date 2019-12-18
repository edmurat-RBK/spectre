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
        transform.position = Vector3.MoveTowards(transform.position,camera.transform.position,  speed * Time.deltaTime);

        transform.LookAt(camera.transform);
        transform.Rotate(new Vector3(0f, 90f, 0f));
    }
}
