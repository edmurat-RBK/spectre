using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteInput : MonoBehaviour
{
    private GameManager gameManager;
    private AudioSource audioSource;

    public Note note;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();
    }

    public void ActionOnClick()
    {
        gameManager.lastInput.Add(note);
        audioSource.Play();
    }
}
