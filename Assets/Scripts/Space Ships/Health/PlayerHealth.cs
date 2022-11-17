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
        Display();   
    }

    public void Display()
    {
        healthText.text = health.ToString();
    }

    protected override void Death()
    {
        base.Death();
        GameObject.Find("Canvas").GetComponent<SceneController>().LoadStartScene();
    }
    
}
