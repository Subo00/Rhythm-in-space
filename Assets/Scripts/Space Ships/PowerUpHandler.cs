using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHandler : MonoBehaviour
{
    GameObject player;
    /////Health
    PlayerHealth playerHealth;

    /////Shooting
    [SerializeField] private float spreadTime = 0.0f;
    bool isSpread = false;
    NormalShooting normalShooting;
    SpreadShooting spreadShooting;

    void Start()
    {
        player = gameObject;
        playerHealth = player.GetComponent<PlayerHealth>();
        normalShooting = player.GetComponent<NormalShooting>();
        spreadShooting = player.GetComponent<SpreadShooting>();
    }

    void FixedUpdate()
    {
        TimerSpread();
    }

    public void Heal(int heal)
    {
        playerHealth.health += heal;
        if(playerHealth.health > playerHealth.healthMax)
        {
            playerHealth.health = playerHealth.healthMax;
        }
        playerHealth.Display();
    }

    public void Spread(float time)
    {
        if(!isSpread)
        {
            isSpread = true;
            spreadShooting.enabled = true;
            normalShooting.enabled = false;
        }
        spreadTime += time;
    }

    private void TimerSpread()
    {
        if(spreadTime > 0f)
        {
            spreadTime -= Time.deltaTime;
        }
        else if(spreadTime <= 0f)
        {
            isSpread = false;
            spreadTime = 0f;
            spreadShooting.enabled  = false;
            normalShooting.enabled  = true;
        }
    }
}