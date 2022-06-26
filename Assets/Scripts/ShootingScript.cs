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
        metronom.beats[0].Subject += Shoot;
        metronom.beats[2].Subject += Loot;
    }

    void OnDisable()
    {
        metronom.beats[0].Subject -= Shoot;
        metronom.beats[2].Subject -= Loot;
    }   

    void Loot(){
        Debug.Log("PLL");
    }
    void Shoot()
    {
       Debug.Log("USPIJEH!");// objectPooler.Instance.SpawnFromPool("Laser", transform.position, Quaternion.identity);
    }
}
