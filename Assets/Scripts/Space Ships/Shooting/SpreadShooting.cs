using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadShooting : Shooting
{
    private bool isSpeedNegative = true;
    private void Start()
    {
        isSpeedNegative = speed < 0 ? true : false;
    }
    protected override void Shoot()
    {
        for(int i = -1; i < 2; i++)
        {
            GameObject laser = objectPool.SpawnFromPool(laserName, transform.position + new Vector3(0,0,0),  Quaternion.Euler( new Vector3(0f,0f, 5f*i)));
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(-5f*i, speed); 
            laser.transform.Rotate(new Vector3(0,0,isSpeedNegative? -30f*i : 30f*i )); 
        }
        base.Shoot();
    }
}
