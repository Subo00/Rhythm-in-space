using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealUp : PowerUps
{
    [SerializeField] private int healPoints;
    protected override void Action(Collider2D other)
    {
        other.gameObject.GetComponent<PlayerHealth>().RecieveHealth(healPoints);   
        base.Action(other);
    }
}
