using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Metronom : MonoBehaviour
{
    public static Metronom MetronomInstance;
    public Beat full;
    public int test = 0;
    public ShootingScript ss;

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
    }

    public void Start()
    {
        
    }
    private void FixedUpdate()
    {
        Debug.Log("Test:" + test);
        ss.Receive();
        BeatDetection();
    }
    
    private void BeatDetection()
    {
        full.SetInterval(60.0f / BPM);

        full.AddTime(Time.deltaTime);
    }
}
