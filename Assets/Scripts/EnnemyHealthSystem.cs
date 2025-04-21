using UnityEngine;
using static UnityEditor.Progress;

public class EnnemyHealthSystem : MonoBehaviour
{
    private int EnnemyCurrentHealth;
    private SpaceShooterItems ItemsData;
    [SerializeField] private GameObject EnnemyExplosionEffectPrefab;
    private FlashEffect Flash;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        ItemsData = GetComponent<SpaceShooterItems>();
        EnnemyCurrentHealth = ItemsData.getLife();
        Flash = GetComponent<FlashEffect>(); 
    }

    public void EnnemyTakeDamage(int ammount)
    {
        if(Flash != null)
        {
            Flash.TriggerFlashDamage();
        }
        EnnemyCurrentHealth -= ammount;
        if (EnnemyCurrentHealth < 0)
        {
            Die();
        }
    }
    private void Die()
    {
        if(EnnemyExplosionEffectPrefab != null)
        {
            GameObject fx = Instantiate(EnnemyExplosionEffectPrefab, transform.position, Quaternion.identity);
            Destroy(fx,1f);
        }
        int EnnemyScore = ItemsData.getScoreBonus();
        GameControl.IncrScore(EnnemyScore);
        Destroy(gameObject);
    }
    // Update is called once per frame
    
}
