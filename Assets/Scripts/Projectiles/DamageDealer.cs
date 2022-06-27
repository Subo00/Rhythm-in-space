using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : Projectiles
{
    [SerializeField] private int damage;
    [SerializeField] private float speed;
    protected override void Action(Collider2D other)
    {
       // base.Action(other);
    }
    private void OnEnable()
    {
       rb.velocity = new Vector2(0, speed);
    }
}
