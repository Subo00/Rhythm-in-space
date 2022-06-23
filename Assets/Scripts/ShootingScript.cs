using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    ObjectPooler objectPooler;
    private void start()
    {
        //objectPooler = ObjectPooler.Instance;
    }
    void OnEnable()
    {
        GameManager.OnShoot += Shoot;
        Debug.Log("I did it");
    }

    void OnDisable()
    {
        GameManager.OnShoot -= Shoot;
    }

    void Shoot()
    {
       // objectPooler.Instance.SpawnFromPool("Laser", transform.position, Quaternion.identity);
    }
}
