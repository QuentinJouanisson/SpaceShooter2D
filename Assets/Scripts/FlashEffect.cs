using UnityEngine;

public class FlashEffect : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material FlashDamageMaterial;
    private readonly float flashDuration = 0.1f;
    private void Awake()
    {
        if(spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TriggerFlashDamage()
    {
        if (FlashDamageMaterial != null && defaultMaterial != null)
            StartCoroutine(FlashCoroutine());
    }
    private System.Collections.IEnumerator FlashCoroutine()
    {
        spriteRenderer.material = FlashDamageMaterial;
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.material = defaultMaterial;
    }
}
