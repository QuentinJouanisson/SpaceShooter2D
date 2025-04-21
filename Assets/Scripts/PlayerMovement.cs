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
    [SerializeField] private float thrustForward = 1f;
    [SerializeField] private float thrustAux = 0.5f;
    [SerializeField] private KeyCode[] thrustKeys = { KeyCode.UpArrow, KeyCode.Z, KeyCode.Keypad8 };
    [SerializeField] private KeyCode[] antithrustKeys = { KeyCode.DownArrow, KeyCode.S, KeyCode.Keypad2 };
    [SerializeField] private KeyCode[] rotateLeftKeys = {KeyCode.LeftArrow, KeyCode.A, KeyCode.Keypad7 };
    [SerializeField] private KeyCode[] rotateRightKeys = { KeyCode.RightArrow, KeyCode.E, KeyCode.Keypad9 };
    [SerializeField] private KeyCode[] translateLeftKeys = {KeyCode.Q, KeyCode.Keypad4};
    [SerializeField] private KeyCode[] translateRightKeys = { KeyCode.D, KeyCode.Keypad6};

    [SerializeField] private ParticleSystem thrustEffect;
    [SerializeField] private ParticleSystem antiThrustEffect;
    [SerializeField] private ParticleSystem translateLeftEffect;
    [SerializeField] private ParticleSystem translateRightEffect;

    private void TriggerMovementEffects(KeyCode[] keys, ParticleSystem effect)
    {
        if (IsMoveKeyPressed(keys))
        {
            if (!effect.isPlaying) effect.Play();
        }
        else
        {
            if (effect.isPlaying) effect.Stop();
        }
    }


    private bool IsMoveKeyPressed(KeyCode[] keys)
    {
        foreach (KeyCode key in keys)
        {
            if(Input.GetKey(key)) return true;
        }
        return false;
    }
    private bool IsThrusting() => IsMoveKeyPressed(thrustKeys);
    private bool IsAntiThrusting() => IsMoveKeyPressed(antithrustKeys);
    private bool IsRotatingLeft() => IsMoveKeyPressed(rotateLeftKeys);
    private bool IsRotatingRight() => IsMoveKeyPressed(rotateRightKeys);
    private bool IsTranslatingLeft() => IsMoveKeyPressed(translateLeftKeys);
    private bool IsTranslatingRight() => IsMoveKeyPressed(translateRightKeys);

    private void ApplyThrust(KeyCode[] keys, Vector2 direction)
    {
        if (IsMoveKeyPressed(keys))
        {
            Vector2 force = thrustForce * direction;
            rb.AddForce(force);
        }
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
    //Start
    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
        rb = GetComponent<Rigidbody2D>();
    }

    // FixedUpdate 
    void FixedUpdate()
    {
        float rotationInput = 0f;

        if (IsRotatingLeft())
        {
            rotationInput = 1f;
            rb.MoveRotation(rb.rotation + rotationInput * rotationSpeed * Time.fixedDeltaTime);
        }
        if (IsRotatingRight())
        {
            rotationInput = -1f;
            rb.MoveRotation(rb.rotation + rotationInput * rotationSpeed * Time.fixedDeltaTime);
        }

        ApplyThrust(thrustKeys, thrustForward * transform.up);
        ApplyThrust(antithrustKeys, thrustAux* -transform.up);
        ApplyThrust(translateLeftKeys, thrustAux * -transform.right);
        ApplyThrust(translateRightKeys, thrustAux * transform.right);
    }
    // Update 
    void Update()
    {
        TriggerMovementEffects(thrustKeys, thrustEffect);
        TriggerMovementEffects(antithrustKeys, antiThrustEffect);

        TriggerMovementEffects(translateLeftKeys, translateLeftEffect);
        TriggerMovementEffects(translateRightKeys, translateRightEffect);
    }
}
