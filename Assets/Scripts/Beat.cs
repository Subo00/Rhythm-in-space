using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Beat : Subject
{
    
    private float timer = 0.0f;
    private float interval;

    public void Start()
    {
        
    }
    public void SetInterval(float interval)
    {
        this.interval = interval;
    }

    public void AddTime(float time)
    {
        timer += time;
        if(timer >= interval)
        {
            timer -= interval;
            base.Send();
        }
    }

    public float GetInterval()
    {
        return interval;
    }

   
}
