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
    private WallScript Wall;

    [SerializeField]
    private Vector3 wallStartPos;

    [SerializeField]
    private bool isGameOn;

    public static GameControl instance;

    [SerializeField]
    private EnnemyRowGenerator rowGenerator;

    
    
    void Start()
    {
        isGameOn = true;
        instance = this;
        GameOverGO.SetActive(false);
        instance.scoreIHM.text = "score : 0 ";
        wallStartPos = Wall.gameObject.transform.position;
        Wall.runWall();
        rowGenerator.toggleGenerator();
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
        instance.Wall.stopWall();
        instance.rowGenerator.stopGenerator();
        Debug.Log("STOP GAME OVER ");
    }

    public static void launchRestart()
    {
        instance.isGameOn = true;
        instance.GameOverGO.SetActive(false);
        instance.scoreTotal = 0;
        instance.Wall.runWall();
        instance.Wall.gameObject.transform.position = instance.wallStartPos;
        instance.rowGenerator.toggleGenerator();


        Debug.Log("restart");
    }

    public void OnRestart()
    {
        launchRestart();
    }
}
