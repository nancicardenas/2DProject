using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject speedItem;
    public GameObject beeEnemy;
    public GameObject[] spawnPoints;
    public float timer;
    public float timeBetween;
    public float beeSpawnTime = 5f;
    public bool bee; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    //Update is called once per frame
    void Update()
    {
        //keep track of time 
        timer += Time.deltaTime;
     
        //Instantiate(ground, spawnPoints[0].transform.position, Quaternion.identity);
        
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
            int randNum = Random.Range(0, 3);

            //instantiate an enemy
            Instantiate(beeEnemy, spawnPoints[randNum].transform.position, Quaternion.identity);
        }
        //FIX
        //add one for platforms 

        if (timer > timeBetween)
        {
            //reset timer 
            timer = 0;
            bee = false; 
            //randomly chooses the spawn point 
            int randNum = Random.Range(1, 4);

            //instantiate ground at bottom 
            //Instantiate(ground, spawnPoints[0].transform.position, Quaternion.identity);
            //instantiates speed bost at specific spawn point 

            Instantiate(speedItem, spawnPoints[randNum].transform.position, Quaternion.identity);
        }
    }
}
