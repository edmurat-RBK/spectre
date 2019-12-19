using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MusicScore : ScriptableObject
{
    public AudioClip audio;
    public List<Note> musicScore;
}
