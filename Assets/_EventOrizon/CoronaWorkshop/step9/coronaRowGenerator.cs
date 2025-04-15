using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coronaRowGenerator : MonoBehaviour
{
     public GameObject background;
    public GameObject Wall;
    public GameObject SpawnPoint;//on the background
    public float spawnTime = 3;

    public float initialSpawnTime = 3;

    public float spawnIncTime = 0.1f;

     public int percentSpawn = 30;


     public float minSpawnTime = 0.7f;

    public List<GameObject> models;

    public float ballSpaceInterval = 37f * 0.015f;

    [SerializeField]
    private bool isOn;

    [SerializeField]
    private List<GameObject> instanciedBricks;

    public static coronaRowGenerator instance;

    // Start is called before the first frame update
    void Awake()
    {
        //instanciedBricks = new List<GameObject>();
        //runGenerator();
        instance = this;
    }
    public void stopGenerator(){
        isOn = false;
        StopCoroutine("SpawnLines");
    }

    public void toggleGenerator(){
        isOn = !isOn;
        if(isOn)
            StartCoroutine("SpawnLines");
        else
            StopCoroutine("SpawnLines");
    }

    public void runGenerator(){
        isOn = true;
        spawnTime = initialSpawnTime;
        RemoveBricks();
        instanciedBricks = new List<GameObject>();
        StartCoroutine("SpawnLines");
    }

     IEnumerator SpawnLines()
    {
        SpawnOneLine();
        while (isOn)
        {
            yield return new WaitForSeconds(spawnTime); // TODO calculate based on speed
            SpawnOneLine();
        }
    }

    public void RemoveBricks()
    {
        foreach(Transform child in Wall.transform)
        {
            Destroy(child.gameObject);
        }
    }

    private void SpawnOneLine()
    {
        float totalWidth = background.GetComponent<Renderer>().bounds.size.x;
        float totalHeight = background.GetComponent<Renderer>().bounds.size.y;

        int totalCount = (int)(totalWidth / ballSpaceInterval);
        System.Random random = new System.Random();
        for (int i = 0; i <= totalCount; i++)
        {

            int pickedInt = random.Next(models.Count * 100 / percentSpawn); //le taux de remplissage agit ici (0 à 100%)
            if (pickedInt < models.Count)
            {
                // float offsetX = -totalWidth / 2 + i * ballSpaceInterval;
                // float offsetY = totalHeight / 2;
                float offsetX = SpawnPoint.transform.position.x + i * ballSpaceInterval;
                float offsetY = SpawnPoint.transform.position.y ;
                float offsetZ = 0;
                
                GameObject prefab = models[pickedInt]; ; //manageDifficulty(pickedInt);
                GameObject brick = Instantiate(prefab, new Vector3(offsetX, offsetY, offsetZ), prefab.transform.rotation);
                brick.transform.SetParent(Wall.transform);
            }
        }

    }

     //called by GameManager when new level is passed
    public void incSpeedGeneration(){
        if( (spawnTime-spawnIncTime) >= minSpawnTime){
            spawnTime -= spawnIncTime;
        }
    }

     //called by GameManager when new Kombo id done (decrease speed)
    public void decreaseSpeedGeneration(){
        spawnTime += spawnIncTime;
    }

}
