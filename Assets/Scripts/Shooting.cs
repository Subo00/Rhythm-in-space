using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Shooting : MonoBehaviour
{
    private ObjectPooler objectPool;
    private Metronom metronom;
    private MusicManager MusicManager;
    [SerializeField] protected string laserName;
    [SerializeField] private int shootingInterval;
    
   
    void OnEnable()
    {
        var temp = GameObject.Find("Object Pool");
        objectPool = temp.GetComponent<ObjectPooler>();
        /*
        var gameController = GameObject.FindGameObjectWithTag("GameController");
        metronom = gameController.GetComponent<Metronom>();
        metronom.beats[shootingInterval].Subject += Shoot;
        */
        var tempMusic = GameObject.Find("MusicManager");
        MusicManager = tempMusic.GetComponent<MusicManager>();
        MusicManager.chanals[0].Subject += Shoot;
    }

    void OnDisable()
    {
        MusicManager.chanals[0].Subject -= Shoot;
        //metronom.beats[shootingInterval].Subject -= Shoot;
    }   

    
    void Shoot()
    {
       objectPool.SpawnFromPool(laserName, transform.position + new Vector3(0,0,0), Quaternion.identity);
    }
}
