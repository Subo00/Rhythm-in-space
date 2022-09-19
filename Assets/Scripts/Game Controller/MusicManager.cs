using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MusicManager : MonoBehaviour
{
    
    [System.Serializable]
    public class Chanal
    {
        public string tag;
        public GameObject[] barsGO;
        public GameObject currentBarGO;
        public event Action Subject = delegate{};
        public void CallInvoke()
        {
            Debug.Log(tag + " Invoked!");
            Subject.Invoke();
        }
    }
                            //  <index, duration>
    [SerializeField] private  List<Tuple<int, int>> switchSequance;
    public int switchIndex = 0;
    public int switchCounter = 0;
    [SerializeField] private List<Chanal> chanals;
    private Metronom metronom;
    void OnEnable()
    {
        var gameController = GameObject.FindGameObjectWithTag("GameController");
        metronom = gameController.GetComponent<Metronom>();
        metronom.beats[2].Subject += RythmCount;
        metronom.beats[0].Subject += SwitchCount;
        
        switchSequance = new List<Tuple<int, int>>();
        switchSequance.Add(Tuple.Create(0,4*4));
        switchSequance.Add(Tuple.Create(1,4*12));
        switchSequance.Add(Tuple.Create(2,4*8));
        switchSequance.Add(Tuple.Create(1,4*8));
        switchSequance.Add(Tuple.Create(2,4*16));
        switchSequance.Add(Tuple.Create(1,4*8));
        switchSequance.Add(Tuple.Create(0,4*4));

        SwitchBar(switchSequance[switchIndex].Item1);
        switchCounter = switchSequance[switchIndex].Item2;

        foreach(Chanal chanal in chanals)
        {
            chanal.currentBarGO.SetActive(true);
        }
    }

    void OnDisable()
    {
        metronom.beats[2].Subject -= RythmCount;
        metronom.beats[0].Subject -= SwitchCount;
    }   

    void RythmCount()
    {
        foreach(Chanal chanal in chanals)
        {
            Bar tmp = chanal.currentBarGO.GetComponent<Bar>(); 
            if(tmp.IsTrigger())
            {
                chanal.CallInvoke();
            }
        }

    }

    void SwitchCount()
    {
        if(switchCounter == 0)
        {
            switchIndex++;
            switchCounter = switchSequance[switchIndex].Item2;
            SwitchBar(switchSequance[switchIndex].Item1);

            if(switchIndex == switchSequance.Count)
            {
                this.gameObject.SetActive(false);
            }
        }else
        {
            switchCounter--;
        }
    }

    void SwitchBar(int index)
    {
        foreach(Chanal chanal in chanals)
        {
            chanal.currentBarGO = chanal.barsGO[index];
        }
    }

    public Chanal GetChanal(string tag)
    {
        foreach(Chanal chanal in chanals)
        {
            if(chanal.tag == tag)
            return chanal;
        }
        return null;
    }
}
