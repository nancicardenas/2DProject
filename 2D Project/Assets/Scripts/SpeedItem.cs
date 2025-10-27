using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedItem : MonoBehaviour
{
    //variables used for when speed item is collected 
    public static event Action<float> OnSpeedCollected;
    public float speedMult = 1.5f;

    public ScoreCounter scoreCounter;

    private Animator anim;

    private void Start() {
       GameObject scoreGO = GameObject.Find("ScoreCounter");

       scoreCounter = scoreGO.GetComponent<ScoreCounter>();
    }

    private void Awake() {
        anim = GetComponent<Animator>();
    }

    //when speed boost item is collected invoke speed multiplier and destroy item
    public void Collect() {
        OnSpeedCollected.Invoke(speedMult);
        //try set high score here ?
        //
        Destroy(gameObject);
        scoreCounter.score += 200;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            scoreCounter.score += 200;
            Collect();
        }
    }

    //STILL NEED TO TEST 
    //animation for speed item whenever it is visbile on screen 
    private void OnBecameVisible() {
        anim.SetTrigger("idleSpeedItem");
        //might not need this 
        enabled = true;
    }

    private void OnBecameInvisible() {
        enabled = false;
        Destroy(gameObject);
    }
}
