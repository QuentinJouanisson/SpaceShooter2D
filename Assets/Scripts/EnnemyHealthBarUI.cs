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

        if (EnnemyHPSlider == null)
            EnnemyHPSlider = GetComponentInChildren<Slider>();

        if (EnnemyHPSlider != null && ennemyHealth != null)
        {
            EnnemyHPSlider.maxValue = ennemyHealth.EnnemyMaxHealth;
            EnnemyHPSlider.value = ennemyHealth.EnnemyCurrentHealth;
            healthbarTransform = EnnemyHPSlider.transform.parent;
        }

        //GameObject healthBarInstance = Instantiate(healthBarPrefab, transform.position + offset, Quaternion.identity, transform);         //instanciate dans le cas ou on a vraiment bcp trop d'ennemy a gerer ou des ennemy class procéduraux

        //EnnemyHPSlider = healthBarInstance.GetComponentInChildren<Slider>();
        //EnnemyHPSlider.maxValue = ennemyHealth.EnnemyMaxHealth;
        //EnnemyHPSlider.value = ennemyHealth.EnnemyCurrentHealth;

        //healthbarTransform = healthBarInstance.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(EnnemyHPSlider != null && ennemyHealth != null)
        {
            EnnemyHPSlider.value = ennemyHealth.EnnemyCurrentHealth;
            if(healthbarTransform != null)
            {
                healthbarTransform.position = transform.position + offset;
            }
            
        }
        
    }
}
