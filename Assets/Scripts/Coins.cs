using UnityEngine;

public class Coins : MonoBehaviour
{
    GameManagerScript gm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        gm = FindObjectOfType<GameManagerScript>();
    }

    // Update is called once per frame

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))

        {
            Destroy(other.gameObject);
            gm.coins += 1;
            print(gm.coins);
            
        }
    }
}
