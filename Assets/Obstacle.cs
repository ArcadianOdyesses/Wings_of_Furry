using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int damageAmount = 10; // Amount of damage to deal to the player
    public float jumpForce = 10f; // Force applied to the player when jumping on the obstacle

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamagePlayer(damageAmount); // Deal damage to the player
            }

            Rigidbody2D playerRigidbody = other.GetComponent<Rigidbody2D>();
            if (playerRigidbody != null)
            {
                // Apply upward force to the player to simulate jumping off the obstacle
                playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpForce);
            }
        }
    }
}
