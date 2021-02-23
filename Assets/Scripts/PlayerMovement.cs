using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{


    public GameObject bullet;

    public bool isGameOver = false;

    private Rigidbody2D rb;

    public GameObject fireSlot;

    public GameObject ship;

    

    public float t = 0.0f;

    public bool moving = false;

    void Awake()
    {

        rb = ship.GetComponent<Rigidbody2D>();
        ship.GetComponent<BoxCollider2D>(); 


    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(moving == false)
        {
            rb.velocity = new Vector2(0f, 0f);
        }


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moving = true;
            rb.velocity = new Vector2(-5.0f, 0.0f);
            
            t = 0.0f;
        }
        else
        {
            moving = false;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            moving = true;
            rb.velocity = new Vector2(6.0f, 0.0f);
            
            t = 0.0f;
        }
        else
        {
            moving = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        isGameOver = true;
        //Time.timeScale = 0;
        Debug.Log(isGameOver);
    }

    public GameObject Shoot()
    {
       
       GameObject projectile = Instantiate(bullet, fireSlot.transform.position, Quaternion.identity) as GameObject;

        projectile.GetComponent<Rigidbody2D>().AddForce(transform.right * 100);

        Physics2D.IgnoreCollision(projectile.GetComponent<BoxCollider2D>(), ship.GetComponent<BoxCollider2D>());

        return projectile;
        
    }

    
        
       
    
}
