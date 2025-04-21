using UnityEngine;
using UnityEngine.UI;


public class EnnemyHealthBarUI : MonoBehaviour
{
    [SerializeField] private EnnemyHealthSystem ennemyHealth;
    [SerializeField] private GameObject healthBarPrefab;
    [SerializeField] private Vector3 offset = new Vector3 (0, 1.5f, 0);

    private Slider EnnemyHPSlider;
    private Transform healthbarTransform;


    void Start()
    {
        if (ennemyHealth == null)
            ennemyHealth = GetComponent<EnnemyHealthSystem>();

        GameObject healthBarInstance = Instantiate(healthBarPrefab, transform.position + offset, Quaternion.identity, transform);

        EnnemyHPSlider = healthBarInstance.GetComponentInChildren<Slider>();
        EnnemyHPSlider.maxValue = ennemyHealth.EnnemyMaxHealth;
        EnnemyHPSlider.value = ennemyHealth.EnnemyCurrentHealth;

        healthbarTransform = healthBarInstance.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(EnnemyHPSlider != null && ennemyHealth != null)
        {
            EnnemyHPSlider.value = ennemyHealth.EnnemyCurrentHealth;
            healthbarTransform.position = transform.position + offset;
        }
        
    }
}
