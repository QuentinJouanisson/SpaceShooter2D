using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class WallScript : MonoBehaviour
{
    public float initialspeed = 0.1f;
    public float speedInc = 0.01f;

    [SerializeField]
    private float speed;

    [SerializeField]
    private bool isOn;
    void Start()
    {
        speed = initialspeed;
    }

   
    void Update()
    {
        if (isOn)
        {
            transform.Translate(new Vector3(0, -speed, 0) * Time.fixedDeltaTime);
        }
    }

    public void stopWall()
    {
        isOn = false;

    }
    public void runWall()
    {
        speed = initialspeed;
        isOn = true;

    }
    public void incSpeedWall()
    {
        speed += speedInc;
    }
    public void decreaseSpeedWall()
    {
        if ((speed - speedInc) > initialspeed)
            speed -= speedInc;
    }
}
