using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProjectileCollisionController : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D collision)
    {
        //ancienne methode 
        //if (collision.gameObject.CompareTag("ENNEMY"))
        //{
        //    SpaceShooterItems item = collision.gameObject.GetComponent<SpaceShooterItems>();
        //    int scorewon = item.getScoreBonus();
        //    GameControl.IncrScore(scorewon);
        //    Destroy(collision.gameObject);
        //    Destroy(gameObject); // a mettre dans une condition si on est buff� par tir traversant
        //}
        //if (collision.gameObject.CompareTag("LargeEnnemy"))
        //{
        //    SpaceShooterItems item = collision.gameObject.GetComponent<SpaceShooterItems>();
        //    int scorewon = item.getScoreBonus();           
        //    GameControl.IncrScore(scorewon);           
        //    collision.gameObject.SetActive(false);
        //    Destroy(gameObject); // a mettre dans une condition si on est buff� par tir traversant

        //}
        if (collision.gameObject.CompareTag("ENNEMY") || collision.gameObject.CompareTag("LargeEnnemy"))
        {
            EnnemyHealthSystem health = collision.GetComponent<EnnemyHealthSystem>();
            if (health != null)
            {
                health.EnnemyTakeDamage(1); // possibilit� d'instancier ici une var de damage ou d'appler un damage modifier externe (pk pas modifi� par une coroutine par exemple pour un buff momentann�)
            }
            Destroy(gameObject); // sauf si buff tir traversant 
        }
        if (collision.gameObject.CompareTag("BONUS") || collision.gameObject.CompareTag("MALUS"))
        {
            SpaceShooterItems item = collision.gameObject.GetComponent<SpaceShooterItems>();
            int scorewon = item.getScoreBonus();
            GameControl.IncrScore(scorewon); // on appelle la methode static pour raise le score par les point trouv�s dans la lsite
            Destroy(collision.gameObject);
            Destroy(gameObject); // a mettre aussi dans une condition si on est buff� par tir traversant
        }
        if (collision.gameObject.CompareTag("BOUNDS"))
        {
            Destroy(gameObject);
            //on peut appeller ici un effet sp�cial pour bien diff�rencier le hit de la border et le hit des ennemis en bordure d'ecran
        }
    }
}
