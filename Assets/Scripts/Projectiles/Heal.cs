using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : Projectiles
{
    [SerializeField] private int healPoints;
    protected override void Action(Collider2D other)
    {
        if(other.tag == "Player")
        {
            other.gameObject.GetComponent<Health>().RecieveHealth(healPoints);
        }
    }
}
