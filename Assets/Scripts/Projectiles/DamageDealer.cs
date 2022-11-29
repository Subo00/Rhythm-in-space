using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : Projectiles
{
    [SerializeField] private int damage;
    [SerializeField] private string ignoreTag;
    
    protected override void Action(Collider2D other)
    {
      if(other.CompareTag(ignoreTag) || other.CompareTag("Wall") ) return;
      other.GetComponent<Health>().RecieveDamge(damage);
      base.Action(other);
    }
    
}
