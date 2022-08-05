using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadUp : PowerUps
{
    [SerializeField] private float spreadTime;
    protected override void Action(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        handler.Spread(spreadTime);
        
        base.Action(other);
    }
}
