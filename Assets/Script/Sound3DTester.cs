using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound3DTester : MonoBehaviour
{
    private AudioSource audioSource;

    public float distance;
    public float angle;
    public float angleSpeed;

    private float xPosition;
    private float zPosition;

    public bool soundLoopActive = true;
    public float soundTime;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        xPosition = Mathf.Cos(Mathf.Deg2Rad * angle) * distance;
        zPosition = Mathf.Sin(Mathf.Deg2Rad * angle) * distance;

        StartCoroutine("PlaySound");
    }

    private void Update()
    {
        angle = (angle + angleSpeed) % 360;

        xPosition = Mathf.Cos(Mathf.Deg2Rad * angle) * distance;
        zPosition = Mathf.Sin(Mathf.Deg2Rad * angle) * distance;

        transform.position = new Vector3(xPosition, 0f, zPosition);
    }

    IEnumerator PlaySound()
    {
        while(soundLoopActive)
        {
            audioSource.Play();
            yield return new WaitForSeconds(soundTime);
        }
    }
}
