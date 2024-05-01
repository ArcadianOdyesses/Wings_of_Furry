using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damageAmount = 10; // Amount of damage the player's attack deals

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object collided with is an enemy
        EnemyHealth enemy = other.GetComponent<EnemyHealth>();
        
        // If the collided object has an EnemyHealth component
        if (enemy != null)
        {
            // Deal damage to the enemy
            enemy.TakeDamage(damageAmount);
        }
    }
}
