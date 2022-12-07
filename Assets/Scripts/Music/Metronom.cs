using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Metronom : MonoBehaviour
{
    public static Metronom MetronomInstance;
    public Beat[] beats;
    

    [SerializeField] private float BPM;
    public void Awake()
    {
        if(MetronomInstance != null && MetronomInstance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            MetronomInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        
        beats[0].SetInterval(60.0f / BPM);
        for(int i = 1; i < beats.Length; i++)
        {
            beats[i].SetInterval(beats[i-1].GetInterval()/ 2);
        }
    }

    private void FixedUpdate()
    {
        BeatDetection();
    }
    
    private void BeatDetection()
    {
        for(int i = 0; i < beats.Length; i++)
        {
            beats[i].AddTime(Time.deltaTime);
        }
    }
}
