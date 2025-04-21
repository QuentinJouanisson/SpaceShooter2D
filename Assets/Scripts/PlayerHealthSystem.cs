using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerHealthSystem : MonoBehaviour
{

    public int playerMaxHealth = 100;
    public int playerCurrentHealth;

    public delegate void OnDeath();
    public event OnDeath AtDeath;

    public delegate void OnHealthChanged(int newHealth);
    public event OnHealthChanged ChangeHealth;

    private FlashEffect Flash;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerCurrentHealth = playerMaxHealth;
        Flash = GetComponent<FlashEffect>();
    }

    public void TakeDamages(int amount)
    {
        if (Flash != null)
        {
            Flash.TriggerFlashDamage();
        }
        playerCurrentHealth -= amount; 
        playerCurrentHealth = Mathf.Max(playerCurrentHealth, 0);

        if (playerCurrentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        AtDeath?.Invoke();
    }
    public void ResetHealth()
    {
        playerCurrentHealth = playerMaxHealth;
        ChangeHealth?.Invoke(playerCurrentHealth);
    }
}
