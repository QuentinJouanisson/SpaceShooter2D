using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProjectileCollisionController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("ENNEMY"))
        {
            SpaceShooterItems item = collision.gameObject.GetComponent<SpaceShooterItems>();
            int scorewon = item.getScoreBonus();

            Debug.Log("Collision detected with ennemy" + scorewon);

            GameControl.incrScore(scorewon);

            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("BOUNDS"))
        {
            Destroy(gameObject);
        }
    }
}
