using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Beat : MonoBehaviour
{
    public event Action Subject = delegate{};
    private float timer;
    private float interval;

    public void AddTime(float time)
    {
        timer += time;
        if(timer >= interval)
        {
            timer -= interval;
            Subject.Invoke();
        }
    }

    public void SetInterval(float interval) { this.interval = interval; }

    public float GetInterval() { return interval; }
   
}
