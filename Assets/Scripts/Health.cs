using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    GameManagerScript gm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        gm = FindFirstObjectByType<GameManagerScript>();
       
        gm.health = 25;
    }

    //  private void Update()
    //  {
    // if gm.health > 25
    //  {
    // gm.health = 25;
    //   }
    // else if gm.health<0
    //  {
    //print("Game Lose Sad :( :( :(");
    //   }
    //}
    //
    // Update is called once per frame

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Spikes"))

        {
            gm.health -= 1;

            print(gm.health);

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Projectile"))

        {
            gm.health -= 1;

            print(gm.health);

            Destroy(other.gameObject);

        }
    }
}


