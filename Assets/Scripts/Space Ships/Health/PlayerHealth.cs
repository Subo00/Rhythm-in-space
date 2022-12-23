using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : Health
{
    private UIManager uiManager;

    void Start()
    {
        base.Start();
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        Display();
    }
    public override void RecieveDamge(int damage)
    {
        base.RecieveDamge(damage);
        Display();   
    }

    public void Display()
    {
        uiManager.SetHealth((float)health/healthMax);
    }

    protected override void Death()
    {
        base.Death();
        GameObject.Find("Canvas").GetComponent<SceneController>().LoadStartScene();
    }
    
}
