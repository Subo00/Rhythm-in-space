using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadShooting : Shooting
{
    protected override void Shoot()
    {
        AudioSource.Play(); 
        for(int i = -1; i < 2; i++)
        {
            GameObject laser = objectPool.SpawnFromPool(laserName, transform.position + new Vector3(0,0,0),  Quaternion.Euler( new Vector3(0f,0f, 5f*i)));
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(-5f*i, 30f); //ovo uredi, ne smije biti fiksno 30
        }
        base.Shoot();
    }
}
