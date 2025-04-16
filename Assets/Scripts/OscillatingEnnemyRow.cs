using UnityEngine;

public class OscillatingEnnemyRow : MonoBehaviour
{
    [Header("------Oscillation Settings------")]
    public float amplitude = 1f;
    public float frequency = 1f;
    public float startOffsetY = 0f;

    private float initialY;
    private float time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    initialY = transform.position.y + startOffsetY;    
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        float newY = initialY + Mathf.Sin(time * frequency * 2 * Mathf.PI) * amplitude;
        Vector3 newPos = new Vector3(transform.position.x, newY, transform.position.z);
        transform.position = newPos;
    }
}
