using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ShootingScript : MonoBehaviour
{
    ObjectPooler objectPooler;
    private Metronom metronom;
    
   
    void OnEnable()
    {
        var gameController = GameObject.FindGameObjectWithTag("GameController");
        metronom = gameController.GetComponent<Metronom>();
        metronom.full.Subject += Shoot;
    }

    void OnDisable()
    {
        metronom.full.Subject -= Shoot;
    }   

    void Shoot()
    {
       Debug.Log("USPIJEH!");// objectPooler.Instance.SpawnFromPool("Laser", transform.position, Quaternion.identity);
    }
}
