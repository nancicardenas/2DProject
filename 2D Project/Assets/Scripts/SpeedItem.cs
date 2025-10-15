using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedItem : MonoBehaviour
{
    public static event Action<float> OnSpeedCollected;
    public float speedMult = 1.5f;

    private Animator anim;

    private void Awake() {
        anim = GetComponent<Animator>();
    }

    //when speed boost item is collected invoke speed multiplier and destroy item
    public void Collect() {
        OnSpeedCollected.Invoke(speedMult);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            Collect();
        }
    }
    //STILL NEED TO TEST 
    //animation for speed item whenever it is visble on screen 
    private void OnBecameVisible() {
        anim.SetTrigger("idleSpeedItem");
        //might not need this 
        enabled = true;
    }

    private void OnBecameInvisible() {
        enabled = false; 
    }
}
