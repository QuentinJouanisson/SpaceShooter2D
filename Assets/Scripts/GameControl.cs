using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;


public class GameControl : MonoBehaviour
{
    [SerializeField]
    private int scoreTotal;

    [SerializeField]
    private TextMeshProUGUI scoreIHM;

    [SerializeField]
    private GameObject GameOverGO;

    [SerializeField]

    private bool isGameOn;

    //coment
    public static GameControl instance ;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isGameOn = true;
        instance = this;
        GameOverGO.SetActive(false);
        instance.scoreIHM.text = "score : 0 ";
    }

    public static void incrScore(int score)
    {
        instance.scoreTotal += score;
        // mise a jour de l'ihm
        instance.scoreIHM.text = "score : "+instance.scoreTotal.ToString();

    }

    public static void OnGameOver()
    {
        instance.isGameOn = false;
        instance.GameOverGO.SetActive(true);
        //TODO stop the count !
        Debug.Log("STOP GAME OVER ");
    }

    public static void launchRestart()
    {
        instance.isGameOn = true;
        instance.GameOverGO.SetActive(false);
        instance.scoreTotal = 0;
        Debug.Log("restart");
    }

    public void OnRestart()
    {
        launchRestart();
    }
}
