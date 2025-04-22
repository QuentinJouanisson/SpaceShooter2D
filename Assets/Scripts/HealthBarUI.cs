using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private PlayerHealthSystem playerHealth;
    private Slider PlayerSlider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerSlider = GetComponent<Slider>();
        if(playerHealth == null)
            playerHealth = GetComponent<PlayerHealthSystem>();
        PlayerSlider.maxValue = playerHealth.playerMaxHealth;
        PlayerSlider.value = playerHealth.playerCurrentHealth;
                
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealth != null)
        {
            PlayerSlider.value = playerHealth.playerCurrentHealth;
        }
    }
}
