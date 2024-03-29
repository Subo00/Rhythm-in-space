using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MusicManager : MonoBehaviour
{
    public static MusicManager MusicManagerInstance;
    [System.Serializable]
    public class Chanal
    {
        public string tag;
        public GameObject[] barsGO;
        public GameObject currentBarGO;
        public event Action Subject = delegate{};
        public void CallInvoke()
        {
            Subject.Invoke();
        }
    }
    [System.Serializable]
    public struct SwitchSequance
    {
        public int index;
        public int duration;
    }
    [SerializeField] private  SwitchSequance[] switchSequance;
    private int switchIndex = 0;
    private int switchCounter = 0;
    [SerializeField] private List<Chanal> chanals;
    private Metronom metronom;
    
    void OnEnable()
    {
        if(MusicManagerInstance != null && MusicManagerInstance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            MusicManagerInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        
        var gameController = GameObject.FindGameObjectWithTag("GameController");
        metronom = gameController.GetComponent<Metronom>();
        metronom.beats[2].Subject += RythmCount;
        metronom.beats[0].Subject += SwitchCount;

        SwitchBar(switchSequance[switchIndex].index);
        switchCounter = switchSequance[switchIndex].duration;
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
            Bar bar = chanal.currentBarGO.GetComponent<Bar>(); 
            if(bar.IsTrigger() && bar)
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

            if (switchIndex == switchSequance.Length)
            {
                Destroy();
            }

            switchCounter = switchSequance[switchIndex].duration;
            SwitchBar(switchSequance[switchIndex].index);           
        }else { switchCounter--; }
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

    public void Destroy()
    {
        GameObject.Find("Canvas").GetComponent<SceneController>().LoadStartScene();
        Destroy(this.gameObject);
        MusicManagerInstance = null;
        return;
    }
}