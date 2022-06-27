using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ShootingScript : MonoBehaviour
{
    private ObjectPooler objectPool;
    private Metronom metronom;
    
    void Start()
    {
        var temp = GameObject.Find("Object Pool");
        objectPool = temp.GetComponent<ObjectPooler>();
    }
   
    void OnEnable()
    {
        var gameController = GameObject.FindGameObjectWithTag("GameController");
        metronom = gameController.GetComponent<Metronom>();
        metronom.beats[2].Subject += Shoot;
        metronom.beats[1].Subject += Loot;
    }

    void OnDisable()
    {
        metronom.beats[2].Subject -= Shoot;
        metronom.beats[1].Subject -= Loot;
    }   

    void Loot(){
        Debug.Log("PLL");
    }
    void Shoot()
    {
       objectPool.SpawnFromPool("Laser", transform.position + new Vector3(0,0,0), Quaternion.identity);
    }
}
