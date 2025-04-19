using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;


public class GameControl : MonoBehaviour
{
    [SerializeField] private int scoreTotal;
    [SerializeField] private TextMeshProUGUI scoreIHM;
    [SerializeField] private TextMeshProUGUI playerShipHPText;
    [SerializeField] private TextMeshProUGUI motherShipHPText;

    [SerializeField] private GameObject GameOverGO;
    [SerializeField] private WallScript Wall;
    [SerializeField] private Vector3 wallStartPos;
    [SerializeField] private bool isGameOn;
    public static bool IsGameOn => instance.isGameOn;
    public static GameControl instance;

    [SerializeField] private EnnemyRowGenerator rowGenerator;
    public PlayerHealthSystem playerHealth;
    public PlayerHealthSystem mothershipHealth;
    public LargeEnnemySpawner largeEnnemySpawner;
    [SerializeField] private SpaceshipShooter shooterScript;
    private int lastWallSpeedScoreStep = 0;
    private int lastMiniBossScoreStep = 0;
    [SerializeField] private int WallSpeedScoreStep = 500;
    [SerializeField] private int MiniBossesSpawnScoreStep = 1000;


    void Start()
    {
        isGameOn = true;
        instance = this;
        GameOverGO.SetActive(false);
        instance.scoreIHM.text = "score : 0 ";
        wallStartPos = Wall.gameObject.transform.position;
        Wall.RunWall();
        rowGenerator.ToggleGenerator();
        playerHealth.AtDeath += OnGameOver;
        mothershipHealth.AtDeath += OnGameOver;
    }

    public static void IncrScore(int score)
    {

        instance.scoreTotal += score;
        // mise a jour de l'ihm
        instance.scoreIHM.text = "score : " + instance.scoreTotal.ToString();

        
        
        if(instance.scoreTotal >= instance.lastWallSpeedScoreStep + instance.WallSpeedScoreStep)
        {
            instance.lastWallSpeedScoreStep += instance.WallSpeedScoreStep;
            instance.Wall.IncSpeedWall();
            Debug.Log("instance score step is " + instance.WallSpeedScoreStep);
            Debug.Log("Wall speed is"+ GameControl.instance.Wall.CurrentSpeed);

        }
        if(instance.scoreTotal >= instance.lastMiniBossScoreStep + instance.MiniBossesSpawnScoreStep)
        {
            instance.lastMiniBossScoreStep += instance.MiniBossesSpawnScoreStep;
            //respawn large ennemies
            instance.largeEnnemySpawner.SpawnEnnemies();
        }


    }
    private void Update()
    {        
            playerShipHPText.text = playerHealth.currentHealth + "/" + playerHealth.maxHealth;
            motherShipHPText.text = mothershipHealth.currentHealth + "/" + mothershipHealth.maxHealth;
    }

    public static void OnGameOver()
    {
        instance.isGameOn = false;
        instance.GameOverGO.SetActive(true);
        instance.Wall.StopWall();
        instance.rowGenerator.StopGenerator();
        instance.shooterScript.enabled = false;

        Rigidbody2D rb = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>(); 
        rb.linearVelocity = Vector2.zero;
        rb.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;     //Freeze the player RBD
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().enabled = false;                    //prevent new imputs

        OscillatingEnnemyRow[] allOscillators = GameObject.FindObjectsByType<OscillatingEnnemyRow>(FindObjectsSortMode.None);
        foreach (OscillatingEnnemyRow osc in allOscillators)
        {
            osc.enabled = false;                                                                           //Stops the BigEnnemies oscillations
        }

    }
    


    public static void LaunchRestart()
    {
        instance.scoreTotal = 0;
        instance.scoreIHM.text = "score : " + instance.scoreTotal.ToString();
        instance.isGameOn = true;
        instance.GameOverGO.SetActive(false);
        instance.playerHealth.ResetHealth();
        instance.mothershipHealth.ResetHealth();
        instance.Wall.RunWall();
        instance.Wall.gameObject.transform.position = instance.wallStartPos;
        instance.rowGenerator.ToggleGenerator();
        instance.shooterScript.enabled = true;

        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().ResetPosAndRot();
        Rigidbody2D rb = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.None;                                                       //Resets the player RBD
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().enabled = true;                     //Resetss the controls

        instance.largeEnnemySpawner.RespawnEnnemies();                                                      //Respawn all ennemies

        OscillatingEnnemyRow[] allOscillators = GameObject.FindObjectsByType<OscillatingEnnemyRow>(FindObjectsSortMode.None);
        foreach (OscillatingEnnemyRow osc in allOscillators)
        {
            osc.enabled = true;                                                                             //Resets the BigEnnemies oscillations
        }
    }

    public void OnRestart()
    {
        LaunchRestart();
    }
}
