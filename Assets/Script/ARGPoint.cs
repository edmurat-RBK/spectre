using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARGPoint : MonoBehaviour
{
    private GameManager gameManager;
    public Text ghostCount;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        ghostCount.text = gameManager.numberGhost.ToString();
    }
}
