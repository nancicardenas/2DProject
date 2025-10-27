using UnityEngine;

public class ProjectileLaunch : MonoBehaviour
{
    private Animator anim; 
    public GameObject projPrefab;
    public Transform launchPoint;

    public float shootTime; //cooldown between projectiles 
    public float shootCounter; //cooldown timer

  

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shootCounter = shootTime; 
    }

    private void Awake()
    {
        anim = GetComponent<Animator>(); 
    }
    // Update is called once per frame
    void Update()
    {
        //if(shootCounter <= 0)
        //{
        //    anim.SetTrigger("shoot");
        //    Instantiate(projPrefab, launchPoint.position, Quaternion.identity);
        //    //restart counter 
        //    shootCounter = shootTime;
        //}
      
        //shootCounter -= Time.deltaTime;
    }
}
