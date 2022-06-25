using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : Observer
{
    ObjectPooler objectPooler;
    private Metronom metronom;
    public override void Receive()
    {
        Debug.Log("USPIJEH!");
    }
    private void start()
    {
        
        //objectPooler = ObjectPooler.Instance;
    }
    void OnEnable()
    {
        var gameController = GameObject.FindGameObjectWithTag("GameController");
        metronom = gameController.GetComponent<Metronom>();
        metronom.full.AddObserver(this);
        Debug.Log("I did it");
    }

    void OnDisable()
    {
        metronom.full.RemoveObserver(this);
     
    }

    void Shoot()
    {
       // objectPooler.Instance.SpawnFromPool("Laser", transform.position, Quaternion.identity);
    }
}
