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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !hasFired)
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
        Vector3 currentMouseClickWorldSpace = cam.ScreenToWorldPoint(Input.mousePosition);
        GameObject shotFired = Instantiate(projectilePrefab, startPos.position, Quaternion.identity);

        //Calculating Projectile Vector
        var heading = currentMouseClickWorldSpace - startPos.position;
        var distance = heading.magnitude;
        var dir = heading / distance;

        dir.z = 0;
        dir.x = (float)System.Math.Round(dir.x,2);
        dir.y = (float)System.Math.Round(dir.y,2);
        dir = dir.normalized;

        //calculate Force
        Vector3 force = dir * projectileSpeedMultiplier * Time.fixedDeltaTime;
        shotFired.GetComponent<Rigidbody2D>().AddForce(force);  
        Destroy(shotFired,lifetime);

        startTime = Time.time;
        hasFired = true;

    }
}
