using System;
using UnityEngine;

public class EnemyMoving : MonoBehaviour
{
    private Rigidbody2D body;

    private void OnEnable()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // body.MovePosition();
    }
}