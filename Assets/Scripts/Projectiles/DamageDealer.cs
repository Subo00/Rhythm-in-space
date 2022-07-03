using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : Projectiles
{
    [SerializeField] private int damage;
    [SerializeField] private float speed;
    [SerializeField] private string ignoreTag;
    
    protected override void Action(Collider2D other)
    {
      if(other.tag == ignoreTag || other.tag == "Wall") return;
      //Debug.Log("other: " + other.name);
      other.GetComponent<Health>().RecieveDamge(damage);
      base.Action(other);
    }
    private void OnEnable()
    {
       rb.velocity = new Vector2(0, speed);
    }
}
