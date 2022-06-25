using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject : MonoBehaviour
{
    private List<Observer> observers;
    public void AddObserver(Observer observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(Observer observer)
    {
        observers.Remove(observer);
    }

    public void Send()
    {
        if(observers.Count == 0) return;
        foreach (var observer in observers)
        {
            observer.Receive();
        }
    }
}
