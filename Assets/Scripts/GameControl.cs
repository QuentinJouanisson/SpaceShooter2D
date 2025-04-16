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

#pragma warning disable 0414
    [SerializeField]
    private bool isGameOn;
#pragma warning restore 0414

    public static GameControl instance;

    [SerializeField]
    private EnnemyRowGenerator rowGenerator;

    public PlayerHealthSystem playerHealth;

    public PlayerHealthSystem mothershipHealth;


    void Start()
    {
        isGameOn = true;
        instance = this;
        GameOverGO.SetActive(false);
        instance.scoreIHM.text = "score : 0 ";
        wallStartPos = Wall.gameObject.transform.position;
        Wall.runWall();
        rowGenerator.toggleGenerator();
        playerHealth.onDeath += OnGameOver;
        mothershipHealth.onDeath += OnGameOver;
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
        Rigidbody2D rb = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>(); 
        rb.linearVelocity = Vector2.zero;
        rb.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;     //Freeze the player RBD
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().enabled = false;                    //prevent new imputs

        OscillatingEnnemyRow[] allOscillators = GameObject.FindObjectsByType<OscillatingEnnemyRow>(FindObjectsSortMode.None);
        foreach (OscillatingEnnemyRow osc in allOscillators)
        {
            osc.enabled = false;                                                                            //Stops the BigEnnemies oscillations
        }

    }
    


    public static void launchRestart()
    {
        instance.isGameOn = true;
        instance.GameOverGO.SetActive(false);
        instance.scoreTotal = 0;
        instance.Wall.runWall();
        instance.Wall.gameObject.transform.position = instance.wallStartPos;
        instance.rowGenerator.toggleGenerator();

        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().ResetPosAndRot();
        Rigidbody2D rb = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.None;                                                       //Resets the player RBD
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().enabled = true;                     //Resetss the controls
        Debug.Log("restart");

        OscillatingEnnemyRow[] allOscillators = GameObject.FindObjectsByType<OscillatingEnnemyRow>(FindObjectsSortMode.None);
        foreach (OscillatingEnnemyRow osc in allOscillators)
        {
            osc.enabled = true;                                                                             //Resets the BigEnnemies oscillations
        }
    }

    public void OnRestart()
    {
        launchRestart();
    }
}
