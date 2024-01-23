using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    [HideInInspector] public float speed;
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

     
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed, 0f);
    }

    public void Turn()
    {
        
        transform.localScale = new Vector3(-transform.localScale.x, 1f, 1f);
        speed = -speed;
    }
}
