using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private PlayerHealthSystem health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = GetComponent<PlayerHealthSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("ENNEMY") || collision.CompareTag("ENNEMYPROJECTILE"))
        {
            if (health != null)
            {
                health.TakeDamages(20);
            }
            Destroy(collision.gameObject);
        }
    }
}
