using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Metronom metronom;
    void Start()
    {
        var gameController = GameObject.FindGameObjectWithTag("GameController");
        metronom = gameController.GetComponent<Metronom>();
        metronom.beats[0].Subject += Spawn;
    }

    private void Spawn()
    {
        Debug.Log("I spawned something");
    }
}
