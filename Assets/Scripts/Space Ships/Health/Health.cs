using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    protected int health;
    [SerializeField] protected int healthMax;
    protected ObjectPooler objectPool;
    private Scoring score;

    void Start()
    {
        var temp = GameObject.Find("Object Pool");
        objectPool = temp.GetComponent<ObjectPooler>();

        var GC = GameObject.Find("Game Controller");
        score = GC.GetComponent<Scoring>();
    }
    void OnEnable()
    {
        health = healthMax;
    }

    public virtual void RecieveDamge(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Death();
        }
    }
    
    protected virtual void Death()
    {
        //pull an explosion from the pooler
        //pull a drop from the pooler

        //add points
        score.AddPoints(healthMax);
        score.IncrementMultiplier();

        gameObject.SetActive(false);
    }
}
