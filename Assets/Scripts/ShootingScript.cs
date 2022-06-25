using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ShootingScript : MonoBehaviour
{
    ObjectPooler objectPooler;
    private Metronom metronom;
    
    private void start()
    {
        
        //objectPooler = ObjectPooler.Instance;
    }
    void OnEnable()
    {
        var gameController = GameObject.FindGameObjectWithTag("GameController");
        metronom = gameController.GetComponent<Metronom>();
        metronom.full.Subject += Shoot;
        Debug.Log("I did it");
    }

    void OnDisable()
    {
     
    }

    void Shoot()
    {
       Debug.Log("USPIJEH!");// objectPooler.Instance.SpawnFromPool("Laser", transform.position, Quaternion.identity);
    }
}
