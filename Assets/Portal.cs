using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour
{
    public Transform destinationPortal; // The destination portal
    public float transitionDuration = 1.0f; // Duration of background transition

    private bool isTransitioning = false;
    private Camera mainCamera;
    private Vector3 initialCameraPosition;
    private ParallaxBackground background;

    private void Start()
    {
        mainCamera = Camera.main;
        initialCameraPosition = mainCamera.transform.position;
        background = FindObjectOfType<ParallaxBackground>(); // Get reference to the ParallaxBackground script
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object entering the portal is the player
        if (other.CompareTag("Player"))
        {
            // Teleport the player to the destination portal's position
            other.transform.position = destinationPortal.position;

            // Smoothly transition background
            if (!isTransitioning)
            {
                StartCoroutine(TransitionBackground());
            }

            // Stop following the player after entering the portal
            background.StopFollowingPlayer();
        }
    }

    private IEnumerator TransitionBackground()
    {
        isTransitioning = true;
        float elapsedTime = 0f;
        Vector3 initialPosition = mainCamera.transform.position;
        Vector3 targetPosition = destinationPortal.position;

        while (elapsedTime < transitionDuration)
        {
            float t = elapsedTime / transitionDuration;
            mainCamera.transform.position = Vector3.Lerp(initialPosition, targetPosition, t);
            yield return null;
            elapsedTime += Time.deltaTime;
        }

        mainCamera.transform.position = targetPosition;
        isTransitioning = false;
    }
}
