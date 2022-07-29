using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalShooting : Shooting
{
    protected override void Shoot()
    {
        objectPool.SpawnFromPool(laserName, transform.position + new Vector3(0,0,0), Quaternion.identity);
        base.Shoot();
    }
}
