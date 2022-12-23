using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class Scoring : MonoBehaviour
{
    [SerializeField] private int multiplier = 1;
    [SerializeField] private int beatIndex = 0;
  
    private Metronom metronom;
    private UIManager uiManager;
    public int score = 0;


    void OnEnable()
    {
        var canvas = GameObject.Find("Canvas");
        uiManager = canvas.GetComponent<UIManager>();
        
        var gameController = GameObject.FindGameObjectWithTag("GameController");
        metronom = gameController.GetComponent<Metronom>();

        metronom.beats[beatIndex].Subject += DecrementMultiplier;
    }

    void OnDisable()
    {
        metronom.beats[beatIndex].Subject -= DecrementMultiplier;
    }

    public void AddPoints(int points)
    {
        score += points * multiplier;
        uiManager.SetScore(score);
    }

    public void IncrementMultiplier()
    {
        multiplier++;
        uiManager.SetMultiplier(multiplier);
    }

    public void DecrementMultiplier()
    {
        if(multiplier == 1) return;
        multiplier--;
        uiManager.SetMultiplier(multiplier);
    }
}
