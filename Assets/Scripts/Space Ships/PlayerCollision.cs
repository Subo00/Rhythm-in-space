using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private Health playerHealth;
    void Start()
    {
        playerHealth = gameObject.GetComponentInParent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Health enemyHealth = other.gameObject.GetComponent<Health>();
        if (enemyHealth.CompareTag("Enemy"))
        {
            playerHealth.RecieveDamge(enemyHealth.health);
            enemyHealth.RecieveDamge(enemyHealth.health);
        }
    }
}
