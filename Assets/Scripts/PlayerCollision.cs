using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private PlayerHealthSystem health;

    [SerializeField] private float ContactDamageInterval = 0.2f;
    [SerializeField] private int ContactDamageAmmount = 30;
    [SerializeField] private int ProjectileDamageAmmount = 10;
    [SerializeField] private int LargeContactDamageAmmount = 50;
    private float ContactTimer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = GetComponent<PlayerHealthSystem>();
    }


    private void Update()
    {
        if(ContactTimer > 0f)
        {
            ContactTimer -= Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("ENNEMYPROJECTILE"))
        {
            if (health != null)
            {
                health.TakeDamages(ProjectileDamageAmmount);
            }
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("ENNEMY"))
        {
            if (health != null)
            {
                health.TakeDamages(ContactDamageAmmount);                
            }
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("LargeEnnemy"))
        {
            if (health != null)
            {
                health.TakeDamages(LargeContactDamageAmmount);
                ContactTimer = ContactDamageInterval;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!GameControl.IsGameOn) return;
        if(collision.CompareTag("LargeEnnemy") && ContactTimer <= 0f)
        {
            if (health != null)
            {
                health.TakeDamages(ContactDamageAmmount);
                ContactTimer = ContactDamageInterval;
            }
        }
    }
}
