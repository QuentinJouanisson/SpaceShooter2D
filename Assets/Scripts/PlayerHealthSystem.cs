using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerHealthSystem : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

    public delegate void OnDeath();
    public event OnDeath onDeath;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;    
    }

    public void TakeDamages(int amount)
    {
        currentHealth -= amount;
        Debug.Log($"{gameObject.name} a {currentHealth} HP");

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log($"{gameObject.name} est détruit !");
        onDeath?.Invoke();
        //Destroy(gameObject);
        //GameControl.OnGameOver();
    }

    // Update is called once per frame
}
