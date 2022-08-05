using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    public int healthMax;
    protected ObjectPooler objectPool;
    private Scoring score;
    [Range(0f,1f)]
    [SerializeField] protected float dropChance;
    [SerializeField] private string dropName;

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
        float randomNumber = Random.Range(0f,1f);
        if(dropChance >= randomNumber)
        objectPool.SpawnFromPool(dropName, gameObject.transform.position, Quaternion.identity );
        
        //add points
        score.AddPoints(healthMax);
        score.IncrementMultiplier();

        gameObject.SetActive(false);
    }
}
