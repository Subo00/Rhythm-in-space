using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Shooting : MonoBehaviour
{
    [SerializeField] protected string laserName;

    private ObjectPooler objectPool;
    private Metronom metronom;
    private MusicManager MusicManager;
    [SerializeField] private string chanalTag;
    
    private AudioSource AudioSource;
   
   
    void OnEnable()
    {
        AudioSource = GetComponent<AudioSource>();
    
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
        AudioSource.Play(); 
        objectPool.SpawnFromPool(laserName, transform.position + new Vector3(0,0,0), Quaternion.identity);
    }
}
