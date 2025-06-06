using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class WallScript : MonoBehaviour
{
    public float initialspeed = 0.3f;
    public float speedInc = 0.02f;

    [SerializeField]
    private float speed;

    [SerializeField]
    private bool isOn;

    public float CurrentSpeed => speed; // expression lambda qui reviens a exposer en readonly une public (au lieu de faire un return)
    void Start()
    {
        speed = initialspeed;
    }

   
    void Update()
    {
        if (isOn)
        {
            transform.Translate(new Vector3(0, -speed, 0) * Time.deltaTime);
        }
    }

    public void StopWall()
    {
        isOn = false;

    }
    public void RunWall()
    {
        speed = initialspeed;
        isOn = true;

    }
    public void IncSpeedWall()
    {
        speed += speedInc;
    }
    public void DecreaseSpeedWall()
    {
        if ((speed - speedInc) > initialspeed)
            speed -= speedInc;
    }
}
