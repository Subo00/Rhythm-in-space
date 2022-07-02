using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Shooting : MonoBehaviour
{
    private ObjectPooler objectPool;
    private Metronom metronom;
    [SerializeField] protected string laserName;
    [SerializeField] private int shootingInterval;
    
   
    void OnEnable()
    {
        var temp = GameObject.Find("Object Pool");
        objectPool = temp.GetComponent<ObjectPooler>();

        var gameController = GameObject.FindGameObjectWithTag("GameController");
        metronom = gameController.GetComponent<Metronom>();
        metronom.beats[shootingInterval].Subject += Shoot;
    }

    void OnDisable()
    {
        metronom.beats[shootingInterval].Subject -= Shoot;
    }   

    
    void Shoot()
    {
       objectPool.SpawnFromPool(laserName, transform.position + new Vector3(0,0,0), Quaternion.identity);
    }
}
