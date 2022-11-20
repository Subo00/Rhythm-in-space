using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 0.5f;
    private Material material;

    private Vector2 offSet;

    void Start() 
    {
        material = GetComponent<Renderer>().material;
        offSet = new Vector2(0f, scrollSpeed);
    }

    void Update()
    {
        material.mainTextureOffset += offSet * Time.deltaTime;
    }

}