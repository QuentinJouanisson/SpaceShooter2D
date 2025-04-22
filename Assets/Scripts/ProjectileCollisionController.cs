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
                health.EnnemyTakeDamage(1); // possibilité d'instancier ici une var de damage ou d'appler un damage modifier externe (pk pas modifié par une coroutine par exemple pour un buff momentanné)
            }
            Destroy(gameObject); // sauf si buff tir traversant 
        }
        if (collision.gameObject.CompareTag("BONUS") || collision.gameObject.CompareTag("MALUS"))
        {
            SpaceShooterItems item = collision.gameObject.GetComponent<SpaceShooterItems>();
            int scorewon = item.getScoreBonus();
            GameControl.IncrScore(scorewon); // on appelle la methode static pour raise le score par les point trouvés dans la lsite
            Destroy(collision.gameObject);
            Destroy(gameObject); // a mettre aussi dans une condition si on est buffé par tir traversant
        }
        if (collision.gameObject.CompareTag("BOUNDS"))
        {
            Destroy(gameObject);
            //on peut appeller ici un effet spécial pour bien différencier le hit de la border et le hit des ennemis en bordure d'ecran
        }
    }
}
