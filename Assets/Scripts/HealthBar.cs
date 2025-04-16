using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image fillImage;
    public PlayerHealthSystem health;

    public void initialize(PlayerHealthSystem system)
    {
        health = system;
    }
    

    // Update is called once per frame
    void Update()
    {
        if (health != null)
        {
            float healthPercent = (float)health.currentHealth / health.maxHealth;
            fillImage.fillAmount = Mathf.Clamp01(healthPercent);
        }
    }
}
