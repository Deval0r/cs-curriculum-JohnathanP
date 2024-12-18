using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float xspeed;
    float xdirection;
    float xvector;
    float yspeed;
    float ydirection;
    float yvector;
    public float playerX;
    public float playerY;
    public int hasAxe;

    public bool overworld; 

    private void Start()
    {
        GetComponentInChildren<TopDown_AnimatorController>().enabled = overworld;
        GetComponentInChildren<Platformer_AnimatorController>().enabled = !overworld; //what do you think ! means?
        xspeed = 4;
        xdirection = 0;
        xvector = 0;
        yspeed = 4;
        ydirection = 0;
        yvector = 0;
        hasAxe = 0;
        if (overworld)
        {
            
            GetComponent<Rigidbody2D>().gravityScale = 0f;
        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }

    private void Update()
    {
        
        xdirection = Input.GetAxis("Horizontal");
        xvector = xspeed * xdirection * Time.deltaTime;
        transform.Translate(xvector, 0, 0);



        if (overworld)
        {
            

            ydirection = Input.GetAxis("Vertical");
            yvector = yspeed * ydirection * Time.deltaTime;
            transform.Translate(0, yvector, 0);
            playerX = transform.position.x;
            playerY = transform.position.y;

        }
        else
        {
            yspeed = 0;
        }
    

    }
    // had float on xdirection and xvector
    //private void OnTriggerEnter2D(Collider2D other)
    //{
        //if (other.gameObject.CompareTag("Coin"))

        //{
            //Destroy(other.gameObject);
        //}
    //}
    //private void OnCollisionEnter2D(Collision2D other)
    //{
        //if (other.gameObject.CompareTag("Wall"))

        //{
           // print("we hit wall lol");
        //}
    //}

    //for organization, put other built-in Unity functions here





    //after all Unity functions, your own functions can go here
}