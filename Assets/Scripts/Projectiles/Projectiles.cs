using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    private Collider2D capsuleCollider;
    void Start()
    {
        capsuleCollider = gameObject.GetComponent<Collider2D>();
        if(!capsuleCollider)
        {
            Debug.LogWarning(gameObject.name + " needs a Collider2D");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Action(other);
        gameObject.SetActive(false);
    }

    protected virtual void Action(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
    }
}
