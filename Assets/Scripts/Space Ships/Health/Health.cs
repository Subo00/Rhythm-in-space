using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Range(0f,1f)]
    [SerializeField] protected float dropChance;
    [SerializeField] private string dropName;
    
    public int health;
    public int healthMax;
    
    protected ObjectPooler objectPool;
    
    private Scoring score;
    private SpriteRenderer spriteRenderer;
    private Material matDefault;
    public Material matWhite;
    protected void  Start()
    {
        var temp = GameObject.Find("Object Pool");
        objectPool = temp.GetComponent<ObjectPooler>();

        var GC = GameObject.Find("Game Controller");
        score = GC.GetComponent<Scoring>();

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        matDefault = spriteRenderer.material;
        matWhite = Resources.Load("Materials/White", typeof(Material)) as Material;
    }
    void OnEnable()
    {
        health = healthMax;
    }

    public virtual void RecieveDamge(int damage)
    {
        spriteRenderer.material = matWhite;
        Invoke("ResetMaterial", 0.2f);
        
        health -= damage;
        if(health <= 0)
        {
            Death();
        }
    }
    
    protected virtual void Death()
    {
        //pull an explosion from the pooler
        objectPool.SpawnFromPool("Explosion", gameObject.transform.position, Quaternion.identity);
        
        //pull a drop from the pooler
        float randomNumber = Random.Range(0f,1f);
        if(dropChance >= randomNumber)
        objectPool.SpawnFromPool(dropName, gameObject.transform.position, Quaternion.identity );
        
        //add points
        score.AddPoints(healthMax);
        score.IncrementMultiplier();

        gameObject.SetActive(false);
    }

    void ResetMaterial() { spriteRenderer.material = matDefault; }
}
