using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private PlayerHealthSystem playerHealth;
    private Slider slider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slider = GetComponent<Slider>();
        if(playerHealth == null)
            playerHealth = GetComponent<PlayerHealthSystem>();
        slider.maxValue = playerHealth.maxHealth;
        slider.value = playerHealth.currentHealth;
                
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealth != null)
        {
            slider.value = playerHealth.currentHealth;
        }
    }
}
