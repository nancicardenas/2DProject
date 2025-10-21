using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyBee : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb; 
    public float speed = 3f; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.tag == "Player")
    //    {

    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = Vector2.left * speed; 
    }
}
