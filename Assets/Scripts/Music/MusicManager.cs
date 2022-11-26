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

    [SerializeField] private int chanaleBeatsDelay = 1;
    private bool rythmBlocked = true;
    private int beatCounter = 0;
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
        if (rythmBlocked) return;
        foreach(Chanal chanal in chanals)
        {
            Bar bar = chanal.currentBarGO.GetComponent<Bar>(); 
            if(bar.IsTrigger())
            {
                chanal.CallInvoke();
            }
        }

    }

    void BeatCount()
    {
        beatCounter++;
        
        if (rythmBlocked)
        {
            chanaleBeatsDelay--;
            if (chanaleBeatsDelay <= 0){ rythmBlocked = false; }
            else { return; }
        }
        
        if(beatCounter == 4){
            beatCounter = 0;        
            foreach(Chanal chanal in chanals)
            {
                chanal.barsGO.Enqueue(chanal.currentBarGO);
                chanal.currentBarGO.SetActive(false);
                chanal.currentBarGO = chanal.barsGO.Dequeue();
                chanal.currentBarGO.SetActive(true);
            }
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
