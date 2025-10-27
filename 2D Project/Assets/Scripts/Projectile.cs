using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D projRb;
    public float speed;

    public float projLife;
    public float projCount; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        projRb = GetComponent<Rigidbody2D>();
        //countdown is set as soon as projectile spawns 
        projCount = projLife;
    }

    // Update is called once per frame
    void Update()
    {
        //countdown and destroy once at 0 
        projCount -= Time.deltaTime;

        if(projCount <= 0)
        {
            Destroy(gameObject); 
        }
    }

    private void FixedUpdate()
    {
        projRb.linearVelocity = Vector2.left * speed;
    }
}
