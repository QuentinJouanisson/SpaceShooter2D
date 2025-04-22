using UnityEngine;

public class RandomRotate : MonoBehaviour
{
    [SerializeField] private float baseRotationSpeed = 10f;
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private float minSpeed = 1.0f;
    private float randomZ;
    private float CurrentRotationSpeed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        randomZ = baseRotationSpeed * Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(0, 0, randomZ);
        Debug.Log("speedvalue is "+ randomZ);
    }
}
