using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedItem : MonoBehaviour
{
    //variables used for when speed item is collected 
    public static event Action<float> OnSpeedCollected;
    public float speedMult = 1.5f;

    //variables used to spawn speed items randomly 
   // public GameObject speedItem;
    //public GameObject[] spawnPoints;
    //public float timer;
    //public float timeBetween;

    private Animator anim;

    private void Start() {
        
    }

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

    // Update is called once per frame
    //void Update() {
    //    //keep track of time 
    //    timer += Time.deltaTime;

    //    //if greater than you want to spawn a random object 
    //    if (timer > timeBetween) {
    //        //reset timer 
    //        timer = 0;
    //        //randomly chooses the spawn point 
    //        int randNum = UnityEngine.Random.Range(0, 4);
    //        //instantiates speed boost at specific spawn point 
    //        Instantiate(speedItem, spawnPoints[randNum].transform.position, Quaternion.identity);
    //    }
    //}
}
