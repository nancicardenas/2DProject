using UnityEngine;

public class PlantEnemy : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;

    public GameObject projPrefab;
    public Transform launchPoint;

    public float shootTime; //cooldown between projectiles 
    public float shootCounter; //cooldown timer


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shootCounter <= 0)
        {
            anim.SetTrigger("Shoot");

            //Instantiate(projPrefab, launchPoint.position, Quaternion.identity);
            //restart counter 
            shootCounter = shootTime;
        }

        shootCounter -= Time.deltaTime;
    }

    public void ShootFireball()
    {
        Instantiate(projPrefab, launchPoint.position, Quaternion.identity);
    }
}
