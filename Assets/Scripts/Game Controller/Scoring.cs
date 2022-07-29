using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class Scoring : MonoBehaviour
{
    [SerializeField] private int multiplier = 1;
    [SerializeField] private int beatIndex = 0;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text multiplierText;

    private Metronom metronom;
    public int score = 0;


    void OnEnable()
    {
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
        scoreText.text = score.ToString();
    }

    public void IncrementMultiplier()
    {
        multiplier++;
        multiplierText.text = multiplier.ToString();
    }

    public void DecrementMultiplier()
    {
        if(multiplier == 1) return;
        multiplier--;
        multiplierText.text = multiplier.ToString();

    }
}
