using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerHealthSystem : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

    public delegate void OnDeath();
    public event OnDeath AtDeath;

    public delegate void OnHealthChanged(int newHealth);
    public event OnHealthChanged ChangeHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;        
    }

    public void TakeDamages(int amount)
    {
        currentHealth -= amount; 
        currentHealth = Mathf.Max(currentHealth, 0);

        if (currentHealth <= 0)
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
        currentHealth = maxHealth;
        ChangeHealth?.Invoke(currentHealth);
    }
}
