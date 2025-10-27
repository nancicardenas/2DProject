using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public ScoreCounter scoreCounter;

    public GameObject speedItem;
    public GameObject beeEnemy;
    public GameObject plantEnemy;
    public GameObject[] spawnPoints;

    public Transform cameraTransform;
    public float spawnNextX = 8f;

    public float timer;
    public float timeBetween;

    public float beeSpawnTime = 5f;
    public bool bee;

    public float plantSpawnTime = 7f; 
    public bool plant;

    private float _beeSpawnTime;
    private float _plantSpawnTime;

    //used for score 
    public float speedMult;
    private float distance;

    private float timeAlive = 1f;

    public bool isPlaying = false;

    //public UnityEvent onPlay = new UnityEvent();

    System.Random random = new System.Random();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();

        //GameManager.Instance.onPlay
    }

    //public void StartGame()
    //{
    //    onPlay.Invoke();
    //    isPlaying = true;
    //}

    //Update is called once per frame
    void Update()
    {
        scoreCounter.score = Mathf.RoundToInt(distance);

        //if(Input.GetKeyDown("k"))
        //{
        //    isPlaying = true;
        //}

        //keep track of time
        timeAlive += Time.deltaTime;
        timer += Time.deltaTime;
        distance += Time.deltaTime * 10f;

        HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);

        //scoreCounter.score += distance; 
        
        //if greater than you want to spawn a random object

        //after an object spawns in after 10 secs they should be off screen so destroy these objects
        if(timer > 10)
        {
            Destroy(gameObject);
        }

        //want to spawn a bee at specific intervals 
        if (timer > beeSpawnTime && bee != true)
        {
            bee = true;
            //fix may just want them at specific spawn points 
            int randNum = UnityEngine.Random.Range(0, 3);

            //instantiate an enemy
            Instantiate(beeEnemy, spawnPoints[randNum].transform.position, Quaternion.identity);
        }

        if(timer > plantSpawnTime && plant != true)
        {
            plant = true;

            int[] plantSpawns = {1, 3};
            int randIndex = random.Next(plantSpawns.Length);

            int num = plantSpawns[randIndex];

            Instantiate(plantEnemy, spawnPoints[num].transform.position, Quaternion.identity);
        }

        //FIX
        //add one for platforms 

        if (timer > timeBetween)
        {
            //reset timer 
            timer = 0;
            bee = false;
            //randomly chooses the spawn point 
            int randNum = UnityEngine.Random.Range(1, 4);

            //Instantiate(ground, spawnPoints[0].transform.position, Quaternion.identity);
            //instantiates speed boost at random spawn point 
            Instantiate(speedItem, spawnPoints[randNum].transform.position, Quaternion.identity);
        }

        //update the spawn points so that it is always in front of the player
        foreach(GameObject point in spawnPoints)
        {
            Vector3 pos = point.transform.position;
            pos.x = cameraTransform.position.x + spawnNextX;
            point.transform.position = pos; 
        }
    }

    //private void ResetFactors()
    //{
    //    timeAlive = 1f;
    //    _beeSpawnTime = beeSpawnTime;
    //    _plantSpawnTime = plantSpawnTime;
    //}
}
