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
        public Queue<GameObject> barsGO;
        public List<GameObject> listBars;
        public GameObject currentBarGO;
        public event Action Subject = delegate{};
        public void CallInvoke()
        {
            Subject.Invoke();
        }
    }
    private int counter = 0;
    public List<Chanal> chanals;
    private Metronom metronom;
    void OnEnable()
    {
        var gameController = GameObject.FindGameObjectWithTag("GameController");
        metronom = gameController.GetComponent<Metronom>();
        metronom.beats[2].Subject += RythmCount;
        metronom.beats[0].Subject += BeatCount;

        foreach(Chanal chanal in chanals)
        {
            chanal.barsGO = new Queue<GameObject>(chanal.listBars);
            chanal.currentBarGO = chanal.barsGO.Dequeue();
            chanal.currentBarGO.SetActive(true);
        }
    }

    void OnDisable()
    {
        metronom.beats[2].Subject -= RythmCount;
        metronom.beats[0].Subject -= BeatCount;
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

    void BeatCount()
    {
        counter++;
        if(counter == 4){
            counter = 0;        
            foreach(Chanal chanal in chanals)
            {
                chanal.barsGO.Enqueue(chanal.currentBarGO);
                chanal.currentBarGO.SetActive(false);
                chanal.currentBarGO = chanal.barsGO.Dequeue();
                chanal.currentBarGO.SetActive(true);
            }
        }
    }
}
