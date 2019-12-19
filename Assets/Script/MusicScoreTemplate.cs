using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScoreTemplate : MonoBehaviour
{
    public List<MusicScore> templates;

    public MusicScore PickOne()
    {
        return templates[Random.Range(0, templates.Count)];
    }
}
