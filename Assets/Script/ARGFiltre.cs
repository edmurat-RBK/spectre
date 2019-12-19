using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ARGFiltre : MonoBehaviour
{
    private GameObject filtre;
    private GameManager gameManager;
    public GameObject[] life = new GameObject[3];
    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        filtre = GameObject.FindWithTag("Filtre");
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Color c = filtre.GetComponent<Image>().color;
        switch (gameManager.miss)
        {
           
            case 0:
                c.a = 0f;
                filtre.GetComponent<Image>().color = c;
                break;
                

            case 1:
                c.a = 0.35f;
                filtre.GetComponent<Image>().color = c;
                life[0].SetActive(true);
                break;

            case 2:
                c.a = 0.70f;
                filtre.GetComponent<Image>().color = c;
                life[1].SetActive(true);
                break;

            case 3:
                c.a = 1f;
                filtre.GetComponent<Image>().color = c;
                life[2].SetActive(true);
                gameOver.SetActive(true);
                StartCoroutine("StartMenu"); //remplacer par un bouton ?
                break;
        }
    }

    IEnumerator StartMenu()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("ARGMenu");
    }
}