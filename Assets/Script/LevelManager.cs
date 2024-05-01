using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Specify the index of the next level to load
    public int nextLevelIndex;

    // Reference to the player object
    public GameObject player;

    // Specify the spawn point number for each level
    public int[] spawnPointNumbers;

    // OnTriggerEnter is called when the Collider other enters the trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player has collided with the trigger
        if (other.CompareTag("Player"))
        {
            // Load the next level
            LoadNextLevel();
        }
    }

    void LoadNextLevel()
    {
        // Load the next level
        SceneManager.LoadScene(nextLevelIndex);

        // Find the spawn point number for the next level
        int spawnPointNumber = GetSpawnPointNumberForLevel(nextLevelIndex);

        // Teleport the player to the spawn point if valid
        if (spawnPointNumber != -1 && spawnPointNumber < spawnPointNumbers.Length)
        {
            TeleportPlayerToSpawnPoint(spawnPointNumber);
        }
        else
        {
            Debug.LogError("Spawn point not found for level " + nextLevelIndex);
        }
    }

    int GetSpawnPointNumberForLevel(int levelIndex)
    {
        // Check if the level index is within range
        if (levelIndex >= 0 && levelIndex < spawnPointNumbers.Length)
        {
            return spawnPointNumbers[levelIndex];
        }
        else
        {
            return -1; // Return -1 if the level index is out of range
        }
    }

    void TeleportPlayerToSpawnPoint(int spawnPointNumber)
    {
        // Find the spawn point GameObject using its number
        GameObject spawnPoint = GameObject.Find("SpawnPoint" + spawnPointNumber);

        // Move the player to the spawn point if found
        if (spawnPoint != null)
        {
            player.transform.position = spawnPoint.transform.position;
        }
        else
        {
            Debug.LogError("Spawn point not found: SpawnPoint" + spawnPointNumber);
        }
    }
}
