using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProjectileCollisionController : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("ENNEMY") || collision.gameObject.CompareTag("BONUS") || collision.gameObject.CompareTag("MALUS"))
        {
            SpaceShooterItems item = collision.gameObject.GetComponent<SpaceShooterItems>();
            int scorewon = item.getScoreBonus();
            GameControl.IncrScore(scorewon);
            Destroy(collision.gameObject);             
        }
        if (collision.gameObject.CompareTag("BOUNDS"))
        {
                Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("LargeEnnemy"))
        {
            SpaceShooterItems item = collision.gameObject.GetComponent<SpaceShooterItems>();
            int scorewon = item.getScoreBonus();           
            GameControl.IncrScore(scorewon);           
            collision.gameObject.SetActive(false);
        }
    }
}
