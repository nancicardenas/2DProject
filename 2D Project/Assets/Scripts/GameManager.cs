using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject speedItem;
    public GameObject[] spawnPoints;
    public float timer;
    public float timeBetween;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    //Update is called once per frame
    void Update()
    {
        //keep track of time 
        timer += Time.deltaTime;

        //if greater than you want to spawn a random object 
        if (timer > timeBetween)
        {
            //reset timer 
            timer = 0;
            //randomly chooses the spawn point 
            int randNum = Random.Range(0, 4);
            //instantiates speed bost at specific spawn point 
            Instantiate(speedItem, spawnPoints[randNum].transform.position, Quaternion.identity);
        }
    }
}
