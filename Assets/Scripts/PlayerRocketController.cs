using UnityEngine;

public class PlayerRocketController : MonoBehaviour
{
    public int rocketCount = 0; // Current number of rockets
    public float initialRocketForce = 10f; // Initial upward force
    public float rocketForceMultiplier = 1.2f; // Exponential multiplier
    public float maxRocketForce = 100f; // Maximum upward force

    private Rigidbody2D rb;
    private bool usingRocket = false;
    private float currentRocketForce = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Activate rocket power when the player presses a key (e.g., space)
        if (Input.GetKeyDown(KeyCode.Space) && rocketCount > 0 && !usingRocket)
        {
            usingRocket = true;
            currentRocketForce = initialRocketForce;
            rocketCount--;
        }

        // Apply upward velocity as long as usingRocket is true
        if (usingRocket)
        {
            ApplyRocketForce();
        }
    }

    private void ApplyRocketForce()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, currentRocketForce); // Add upward velocity
        currentRocketForce *= rocketForceMultiplier; // Increase force exponentially

        if (currentRocketForce >= maxRocketForce) // Cap the rocket force
        {
            currentRocketForce = maxRocketForce;
        }

        if (currentRocketForce < initialRocketForce * 2) // Stop rocket usage after small thrust
        {
            usingRocket = false;
            currentRocketForce = 0f;
        }
    }

    public void AddRocket()
    {
        if (rocketCount < 5)
        {
            rocketCount++;
        }
    }
}
