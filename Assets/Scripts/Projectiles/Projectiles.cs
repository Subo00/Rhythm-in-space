using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    private Collider2D col;
    protected Rigidbody2D rb;
    void Awake()
    {
        col = gameObject.GetComponent<Collider2D>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        
        if(!col)
        {
            Debug.LogWarning(gameObject.name + " needs a Collider2D");
        }
        if(!rb)
        {
            Debug.LogWarning(gameObject.name + " needs a Rigidbody2D");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Action(other);
    }

    protected virtual void Action(Collider2D other)
    {
        gameObject.SetActive(false);
    }
}
