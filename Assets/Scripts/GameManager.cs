using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //public static GameManager current;
    public delegate void PlayerShoot();
    public static event PlayerShoot OnShoot;

    private void FixedUpdate()
    {
        
    }
}
