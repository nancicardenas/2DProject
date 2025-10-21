using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //[SerializeField] public float speed;
    [Header("Movement")]
    public float speed = 5f;
    float speedMult = 1f;

    private Rigidbody2D body;
    private Animator anim;

    private bool grounded;
    private bool attacked;
    //references for rigid body and animator of object 
    private void Awake() {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        SpeedItem.OnSpeedCollected += StartSpeedBoost; 
    }

    //starts the coroutine to do the speed boost when item is collected 
    void StartSpeedBoost(float mult)
    {
        StartCoroutine(SpeedBoostCoroutine(mult));
    }


    //speed boost is enabled for 5 seconds before going back to regular speed 
    private IEnumerator SpeedBoostCoroutine(float mult)
    {
        speedMult = mult;
        yield return new WaitForSeconds(5f);
        speedMult = 1f;
    }

    // Update is called once per frame
    private void Update() {
        float horizontalInput = Input.GetAxis("Horizontal");
        //might change so that it moves on its own not sure yet 
        //everytime you place the left button it goest to -1 and everytime you press the right key it goes to 1 
        body.linearVelocity = new Vector2(horizontalInput * speed * speedMult, body.linearVelocity.y);

        //if player moves right then character sprite also turns right 
        if(horizontalInput > 0.01f) {
            transform.localScale = Vector3.one;
        }
        //player moves left 
        else if(horizontalInput < -0.01f) {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        //check if player is jumping
        if (Input.GetKey(KeyCode.UpArrow) && grounded) {
            Jump();
        }
        //set animator parameters

        //running animation when true 
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);
    }

    //is called whenever player jumps 
    private void Jump() {
        body.linearVelocity = new Vector2(body.linearVelocity.x, speed * 2.5f);
        anim.SetTrigger("jump");

        grounded = false;
    }

    //detect collisions 
    private void OnCollisionEnter2D(Collision2D coll)  {
        GameObject collidedWith = coll.gameObject;

        if(collidedWith.CompareTag("Ground")) {
            grounded = true;
        }

        if (collidedWith.CompareTag("BeeEnemy"))
        {
            SceneManager.LoadScene(0);
        }
    }

}
