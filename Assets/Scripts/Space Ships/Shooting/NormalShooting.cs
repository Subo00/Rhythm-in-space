using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalShooting : Shooting
{
    protected override void Shoot()
    {
        GameObject bullet = objectPool.SpawnFromPool(laserName, transform.position + new Vector3(0,0,0), Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
        base.Shoot();
    }
}
