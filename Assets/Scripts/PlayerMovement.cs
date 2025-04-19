using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private Quaternion startRotation;

    [SerializeField] private float thrustForce = 1.5f;
    [SerializeField] private float rotationSpeed = 350f;
    [SerializeField] private KeyCode[] thrustKeys = { KeyCode.UpArrow, KeyCode.Z, KeyCode.Keypad8 };
    [SerializeField] private KeyCode[] antithrustKey = { KeyCode.DownArrow, KeyCode.S, KeyCode.Keypad2 };
    [SerializeField] private KeyCode[] rotateLeftKey = {KeyCode.LeftArrow, KeyCode.A, KeyCode.Keypad9 };
    [SerializeField] private KeyCode[] rotateRightKey = { KeyCode.RightArrow, KeyCode.E, KeyCode.Keypad7 };
    [SerializeField] private KeyCode[] translateLeftKey = {KeyCode.Q, KeyCode.Keypad4};
    [SerializeField] private KeyCode[] translateRightKey = { KeyCode.D, KeyCode.Keypad6};

    private bool IsThrusting()
    {
        foreach(KeyCode key in thrustKeys)
        {
            if(Input.GetKey(key)) return true;
        }
        return false;
    }

    private bool IsAntiThrusting()
    {
        foreach(KeyCode key in antithrustKey)
        {
            if (Input.GetKey(key)) return true;
        }
        return false;
    }

    private bool IsRotatingLeft()
    {
        foreach(KeyCode key in rotateLeftKey)
        {
            if (Input.GetKey(key)) return true;
        }
        return false;
    }
    private bool IsRotatingRight()
    {
        foreach (KeyCode key in rotateRightKey)
        {
            if(Input.GetKey(key)) return true;
        }
        return false;
    }
    private bool IsTranslatingLeft()
    {
        foreach(KeyCode key in translateLeftKey)
        {
            if(Input.GetKey(key)) return true;
        }
        return false;
    }
    private bool IsTranslatingRight()
    {
        foreach(KeyCode key in translateRightKey)
        {
            if(Input.GetKey(key)) return true;
        }
        return false;
    }




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
        float thrustdir = 0f;

       if (IsRotatingLeft())
        {
            rotationInput = 1f;
            rb.MoveRotation(rb.rotation + rotationInput * rotationSpeed * Time.deltaTime);
        }
        if (IsRotatingRight())
        {
            rotationInput = -1f;
            rb.MoveRotation(rb.rotation + rotationInput * rotationSpeed * Time.deltaTime);
        }
        if (IsThrusting())
        {
            thrustdir = 1f;
            Vector2 force = thrustForce * thrustdir * transform.up;
            rb.AddForce(force);
        }
        if (IsAntiThrusting())
        {
            thrustdir = -1f;
            Vector2 force = thrustForce * thrustdir * transform.up;
            rb.AddForce(force);
        }
        if (IsTranslatingLeft())
        {
            thrustdir = -1f;
            Vector2 force = thrustForce * thrustdir * transform.right;
            rb.AddForce(force);
        }
        if (IsTranslatingRight())
        {
            thrustdir = 1f;
            Vector2 force = thrustForce * thrustdir * transform.right;
            rb.AddForce(force);
        }

    }
}
