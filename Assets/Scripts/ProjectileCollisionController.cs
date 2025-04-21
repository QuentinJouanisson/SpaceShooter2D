using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProjectileCollisionController : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D collision)
    {

        //if (collision.gameObject.CompareTag("ENNEMY"))
        //{
        //    SpaceShooterItems item = collision.gameObject.GetComponent<SpaceShooterItems>();
        //    int scorewon = item.getScoreBonus();
        //    GameControl.IncrScore(scorewon);
        //    Destroy(collision.gameObject);
        //    Destroy(gameObject); // a mettre dans une condition si on est buffé par tir traversant
        //}
        //if (collision.gameObject.CompareTag("LargeEnnemy"))
        //{
        //    SpaceShooterItems item = collision.gameObject.GetComponent<SpaceShooterItems>();
        //    int scorewon = item.getScoreBonus();           
        //    GameControl.IncrScore(scorewon);           
        //    collision.gameObject.SetActive(false);
        //    Destroy(gameObject); // a mettre dans une condition si on est buffé par tir traversant

        //}
        if (collision.gameObject.CompareTag("ENNEMY") || collision.gameObject.CompareTag("LargeEnnemy"))
        {
            EnnemyHealthSystem health = collision.GetComponent<EnnemyHealthSystem>();
            if (health != null)
            {
                health.EnnemyTakeDamage(1); // ou une valeur selon ton projectile
            }
            Destroy(gameObject); // sauf si tir traversant
        }
        if (collision.gameObject.CompareTag("BONUS") || collision.gameObject.CompareTag("MALUS"))
        {
            SpaceShooterItems item = collision.gameObject.GetComponent<SpaceShooterItems>();
            int scorewon = item.getScoreBonus();
            GameControl.IncrScore(scorewon);
            Destroy(collision.gameObject);
            Destroy(gameObject); // a mettre dans une condition si on est buffé par tir traversant
        }
        if (collision.gameObject.CompareTag("BOUNDS"))
        {
            Destroy(gameObject);
        }
    }
}
