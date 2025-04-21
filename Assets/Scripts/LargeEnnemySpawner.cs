using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class LargeEnnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject ennemyPrefab;
    [SerializeField] private Transform[] spawnPoints;
    private List<GameObject> spawnedEnnemies = new();
    private readonly float SpawnEffectDuration = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        SpawnEnnemies();
    }

    public void SpawnEnnemies()
    {
        StartCoroutine(Spawning());
    }
    public void UnregisterEnnemy(GameObject MiniBoss)
    {
        if (spawnedEnnemies.Contains(MiniBoss))
        {
            spawnedEnnemies.Remove(MiniBoss);
        }
    }
    private IEnumerator SpawnFX(GameObject MiniBoss, int loops)
    {
        SpriteRenderer sr = MiniBoss.GetComponent<SpriteRenderer>();
        if (sr == null) yield break;

        float interval = SpawnEffectDuration / (loops * 2);
        for (int i = 0; i < loops; i++)
        {
            sr.color = new Color(1f, 1f, 1f, 0.3f);
            yield return new WaitForSeconds(interval);
            sr.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(interval);
        }
    }
    private IEnumerator Spawning()
    {
        spawnedEnnemies.Clear();
        Debug.Log("spanwing" + spawnPoints.Length + "ennemies");
        foreach (Transform spawnPoint in spawnPoints)
        {
            GameObject MiniBoss = Instantiate(ennemyPrefab, spawnPoint.position, Quaternion.identity);
            spawnedEnnemies.Add(MiniBoss);
            MiniBoss.GetComponent<Collider2D>().enabled = false;
            StartCoroutine(SpawnFX(MiniBoss, 10));
        }


            yield return new WaitForSeconds(SpawnEffectDuration);

            foreach(GameObject MiniBoss in spawnedEnnemies)
            {
                if(MiniBoss != null)
                {
                    SpriteRenderer sr = MiniBoss.GetComponent<SpriteRenderer>();
                    if (sr != null)
                        sr.color = new Color(1f, 1f, 1f, 1f);
                    MiniBoss.GetComponent <Collider2D>().enabled = true; 
                }
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
        StopAllCoroutines();
        DestroyEnnemies();
        StartCoroutine(Spawning());
    }
}
