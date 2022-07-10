using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    [SerializeField] private bool[] rythmGates = new bool[16];
    int counter = -1;
    public bool IsTrigger()
    {
        counter++;
        if(counter == 15)
        {
            counter = -1;
            return rythmGates[15];
        }
        return rythmGates[counter];
    }
}
