using UnityEngine;

public class RocketCollectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerRocketController player = collision.GetComponent<PlayerRocketController>();
        if (player != null && player.rocketCount < 5)
        {
            player.AddRocket();
            Destroy(gameObject); // Remove the collectible
        }
    }
}
