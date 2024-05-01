using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    private Animator animator; // Reference to the Animator component

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>(); // Assign the Animator component
    }

    public void TakeDamagePlayer(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            PlayerDie();
        }
        else
        {
            // Trigger hurt animation
            if (animator != null)
            {
                animator.SetTrigger("Hurt");
            }
        }
    }

    void PlayerDie()
    {
        // Implement player death behavior here, such as restarting the level or showing a game over screen
        Debug.Log("Player died!");
        // For now, let's simply deactivate the player gameObject
        gameObject.SetActive(false);

        // Trigger death animation if the Animator component is assigned
        if (animator != null)
        {
            animator.SetTrigger("Die");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // If the player collides with an object tagged as "Enemy", take damage
            TakeDamagePlayer(20); // Adjust damage amount as needed
        }
        else if (other.CompareTag("Obstacle"))
        {
            // If the player collides with an object tagged as "Obstacle", take damage
            TakeDamagePlayer(10); // Adjust damage amount as needed
        }
    }
}
