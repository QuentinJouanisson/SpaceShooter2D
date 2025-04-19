using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpaceshipShooter : MonoBehaviour
{
    [Header("------Shot Parameters------")]
    [SerializeField]
    private float timeToWait;

    [SerializeField]
    private float startTime;

    [SerializeField]
    private bool hasFired;

    [SerializeField]
    private GameObject projectilePrefab;

    [SerializeField]
    private Transform startPos;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private float lifetime;

    [SerializeField]
    private float projectileSpeedMultiplier;

    [SerializeField]
    private KeyCode MainFire = KeyCode.Mouse0;
    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButtonDown("Fire1") && !hasFired)
        if (Input.GetKey(MainFire) && !hasFired)
        {
            ShootProjectile();
        }
        if (hasFired)
        {
            if(Time.time - startTime >= timeToWait)
            {
                hasFired = false;
            }
        }

    }
    private void ShootProjectile()
    {
        Vector3 mouseWorldPos = cam.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;

        Vector3 aimDir = (mouseWorldPos - startPos.position).normalized;
     
        //Debug.Log("ShootDir Magnitude: " + aimDir.magnitude);

        Vector3 forward = transform.up;

        float maxAngle = 15f;
        float angleBetween = Vector3.Angle(forward, aimDir);

        if(angleBetween > maxAngle)
        {
            aimDir = Vector3.RotateTowards(forward, aimDir, Mathf.Deg2Rad * maxAngle, 0f);
        }
        
        GameObject shotFired = Instantiate(projectilePrefab, startPos.position, Quaternion.identity);

        //calculate Force - old method 
        //Vector3 force = shootDir * projectileSpeedMultiplier * Time.fixedDeltaTime;
        //shotFired.GetComponent<Rigidbody2D>().AddForce(force);  
        //Destroy(shotFired,lifetime);

        Rigidbody2D rb = shotFired.GetComponent<Rigidbody2D>();
        rb.linearVelocity = aimDir * projectileSpeedMultiplier;
        Destroy(shotFired, lifetime);


        startTime = Time.time;
        hasFired = true;

        Debug.DrawRay(startPos.position, forward * 2f, Color.green, 1f);
        Debug.DrawRay(startPos.position, aimDir * 2f, Color.red, 1f);

    }
}
