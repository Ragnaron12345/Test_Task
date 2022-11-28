using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar : MonoBehaviour
{
    SpriteRenderer Health = new SpriteRenderer();
    public int health = 10;

    void Start()
    {
        Health = GetComponent<SpriteRenderer>();
        health = 10;
    }

    void Update()
    {
        transform.localScale = new Vector2(health * 2.5f, 5);
    }
}