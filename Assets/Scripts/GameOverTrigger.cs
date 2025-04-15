using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameOverTrigger : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("ENNEMY"))
        {
            PlayerHealthSystem playerHealth = GetComponent<PlayerHealthSystem>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamages(20);
            }

            //Destroy(gameObject);
            //GameControl.OnGameOver();

        }
    }

}
