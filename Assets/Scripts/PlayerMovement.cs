using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private KeyCode moveUpKey = KeyCode.UpArrow;
    [SerializeField] private KeyCode moveDownKey = KeyCode.DownArrow;
    [SerializeField] private KeyCode rotateLeftKey = KeyCode.LeftArrow;
    [SerializeField] private KeyCode rotateRightKey = KeyCode.RightArrow;


    [SerializeField]
    private Transform MyTransform;

    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float screenHalfWidth;

    [SerializeField]
    private float screenHalfHeight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float halfHeight = Camera.main.orthographicSize;
        float halfWidth = halfHeight * Camera.main.aspect;
        screenHalfWidth = halfWidth -0.5f;
        screenHalfHeight = halfHeight - 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            MyTransform.Rotate(0, 0, rotationSpeed * Time.fixedDeltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            MyTransform.Rotate(0, 0, -rotationSpeed * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            MyTransform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            MyTransform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }
            Vector3 pos = MyTransform.position;
        pos.x = Mathf.Clamp(pos.x, -screenHalfWidth, screenHalfWidth);
        pos.y = Mathf.Clamp(pos.y, -screenHalfHeight, screenHalfHeight);
        MyTransform.position = pos;
    }
}
