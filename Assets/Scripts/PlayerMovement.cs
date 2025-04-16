using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private Quaternion startRotation;

    [SerializeField] private float thrustForce = 1.5f;
    [SerializeField] private float rotationSpeed = 200f;
    [SerializeField] private KeyCode thrustKey = KeyCode.UpArrow;
    [SerializeField] private KeyCode rotateLeftKey = KeyCode.LeftArrow;
    [SerializeField] private KeyCode rotateRightKey = KeyCode.RightArrow;

    private Rigidbody2D rb;

    [SerializeField] private float screenHalfWidth;
    [SerializeField] private float screenHalfHeight;

    public void ResetPosAndRot()
    {
        transform.position = startPosition;
        transform.rotation = startRotation;

        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
        rb = GetComponent<Rigidbody2D>();
        float halfHeight = Camera.main.orthographicSize;
        float halfWidth = halfHeight * Camera.main.aspect;
        screenHalfWidth = halfWidth -0.5f;
        screenHalfHeight = halfHeight - 0.5f;
    }

    // Update is called once per frame
    void Update()
    {

        float rotationInput = 0f;
        if (Input.GetKey(rotateLeftKey)) rotationInput = 1f;
        if (Input.GetKey(rotateRightKey)) rotationInput = -1f;

        rb.MoveRotation(rb.rotation +  rotationInput * rotationSpeed * Time.deltaTime);

        if (Input.GetKey(thrustKey))
        {
            Vector2 force = transform.up * thrustForce;
            rb.AddForce(force);
        }

        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    MyTransform.Rotate(0, 0, rotationSpeed * Time.fixedDeltaTime);
        //}
        //else if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    MyTransform.Rotate(0, 0, -rotationSpeed * Time.fixedDeltaTime);
        //}
        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    MyTransform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        //}
        //else if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    MyTransform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        //}
        //    Vector3 pos = MyTransform.position;
        //pos.x = Mathf.Clamp(pos.x, -screenHalfWidth, screenHalfWidth);
        //pos.y = Mathf.Clamp(pos.y, -screenHalfHeight, screenHalfHeight);
        //MyTransform.position = pos;
    }
}
