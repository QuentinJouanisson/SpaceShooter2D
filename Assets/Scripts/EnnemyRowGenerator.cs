using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class EnnemyRowGenerator : MonoBehaviour
{
    public GameObject GameBG;

    public GameObject Wall;

    public GameObject SpawnPoint;

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

    public static EnnemyRowGenerator instance;

    void Awake()
    {
        instance = this;
    }

    public void stopGenerator()
    {
        isOn = false;
        StopCoroutine("SpawnLines");
    }

    public void toggleGenerator()
    {
        isOn = !isOn;
        if (isOn)
            StartCoroutine("SpawnLines");
        else
            StopCoroutine("SpawnLines");

    }

    public void runGenerator()
    {
        isOn=true;
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
            yield return new WaitForSeconds(spawnTime); 
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
        //float totalWidth = GameBG.GetComponent<Renderer>().bounds.size.x;
        //float totalHeight = GameBG.GetComponent <Renderer>().bounds.size.y;

        float totalWidth = 1600;
        

        int totalCount = (int)(totalWidth / ballSpaceInterval);
        System.Random random = new System.Random();
        for (int i = 0; i <= totalCount; i++)
        {
            int pickedInt = random.Next(models.Count * 100 / percentSpawn);
            if (pickedInt < models.Count)
            {
                float offsetX = SpawnPoint.transform.position.x + i * ballSpaceInterval;
                float offsetY = SpawnPoint.transform.position.y;
                float offsetZ = 0;

                GameObject prefab = models[pickedInt]; ;
                GameObject brick = Instantiate(prefab, new Vector3(offsetX, offsetY, offsetZ), prefab.transform.rotation );
                brick.transform.SetParent(Wall.transform);

            }
        }


    }

    public void incSpeedGeneration()
    {
        if((spawnTime-spawnIncTime) >= minSpawnTime)
        {
            spawnTime -= spawnIncTime;
        }
    }

    public void decreaseSpeedGeneration()
    {
        spawnTime += spawnIncTime;
    }
    
}
