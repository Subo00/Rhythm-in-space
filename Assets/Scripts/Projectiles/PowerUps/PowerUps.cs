using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : Projectiles
{
    protected PowerUpHandler handler;
    void OnEnable()
    {
        int layerInt = LayerMask.NameToLayer("PowerUps");
        gameObject.layer = layerInt;
        Debug.Log("Current layer: " + gameObject.layer);
        GameObject player = GameObject.FindWithTag("Player");
        handler = player.GetComponent<PowerUpHandler>();
    }
    protected override void Action(Collider2D other)
    {
        base.Action(other); 
    }
}
