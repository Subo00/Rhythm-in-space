using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : Projectiles
{
    void OnStart()
    {
        int LayerIgnoreRaycast = LayerMask.NameToLayer("PowerUps");
        gameObject.layer = LayerIgnoreRaycast;
        Debug.Log("Current layer: " + gameObject.layer);
    }
    protected override void Action(Collider2D other)
    {
        base.Action(other); 
    }
}
