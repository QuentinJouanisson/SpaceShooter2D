using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class LargeEnnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject ennemyPrefab;
    [SerializeField] private Transform[] spawnPoints;

    private List<GameObject> spawnedEnnemies = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        SpawnEnnemies();
    }

    public void SpawnEnnemies()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            GameObject ennemy = Instantiate(ennemyPrefab, spawnPoint.position, Quaternion.identity);
            spawnedEnnemies.Add(ennemy);
        }
        
    }
    public void DestroyEnnemies()
    {
        foreach (GameObject ennemy in spawnedEnnemies)
        {
            if (ennemy != null)
                Destroy(ennemy);
        }
        spawnedEnnemies.Clear();
    }

    public void RespawnEnnemies()
    {
        DestroyEnnemies();
        SpawnEnnemies();

    }
}
