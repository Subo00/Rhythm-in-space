using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Shooting : MonoBehaviour
{
    [SerializeField] protected string laserName;
    [SerializeField] protected string chanalTag;
    [SerializeField] protected float speed;


    protected ObjectPooler objectPool;
    protected Metronom metronom;
    protected MusicManager MusicManager;    
    protected AudioSource AudioSource;
   
   
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

    
    protected virtual void Shoot()
    {
        AudioSource.Play(); 
    }
}
