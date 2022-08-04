using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : Health
{
    [SerializeField] private TMP_Text healthText;

    public override void RecieveDamge(int damage)
    {
        base.RecieveDamge(damage);
        healthText.text = health.ToString();
    }


    public void RecieveHealth(int heal)
    {
        health += heal;
        if(health > healthMax)
        {
            health = healthMax;
        }
        
        healthText.text = health.ToString();
    }

}
