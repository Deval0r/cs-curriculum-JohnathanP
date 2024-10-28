using UnityEngine;

public class AxeScript : MonoBehaviour
{
    PlayerController playerController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        playerController = FindFirstObjectByType<PlayerController>();

    }

    // Update is called once per frame

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))

        {
            
            playerController.hasAxe = 1;
            Destroy(this.gameObject);

        }
    }
}
