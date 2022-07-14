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
    [SerializeField] private string chanalTag;
    
   
    void OnEnable()
    {
        var temp = GameObject.Find("Object Pool");
        objectPool = temp.GetComponent<ObjectPooler>();
        
        var tempMusic = GameObject.Find("MusicManager");
        MusicManager = tempMusic.GetComponent<MusicManager>();
        MusicManager.GetChanal(chanalTag).Subject += Shoot;
    }

    void OnDisable()
    {
        MusicManager.GetChanal(chanalTag).Subject -= Shoot;
    }   

    
    void Shoot()
    {
       objectPool.SpawnFromPool(laserName, transform.position + new Vector3(0,0,0), Quaternion.identity);
    }
}
