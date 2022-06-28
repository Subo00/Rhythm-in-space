using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] private int healthMax;
    protected ObjectPooler objectPool;

    void Start()
    {
        var temp = GameObject.Find("Object Pool");
        objectPool = temp.GetComponent<ObjectPooler>();
    }
    void OnEnable()
    {
        health = healthMax;
    }

    public void RecieveDamge(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Death();
        }
    }

    protected virtual void Death()
    {
        gameObject.SetActive(false);
    }
}
