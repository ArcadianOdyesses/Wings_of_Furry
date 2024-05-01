using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private float length, startpos;
    public GameObject cam;
    public float parallaxEffect;
    private bool isFollowingPlayer = true; // Flag to control if background should follow the player

    // Reference to the next portal
    public GameObject nextPortal;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowingPlayer)
        {
            float temp = (cam.transform.position.x * (1 - parallaxEffect));
            float dist = (cam.transform.position.x * parallaxEffect);

            transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);
            if (temp > startpos + length) startpos += length;
            else if (temp < startpos - length) startpos -= length;
        }
    }

    // Function to stop following the player
    public void StopFollowingPlayer()
    {
        isFollowingPlayer = false;
    }

    // OnCollisionEnter2D is called when a collision occurs
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with an object tagged as "end"
        if (collision.gameObject.CompareTag("end"))
        {
            // Stop following the player
            StopFollowingPlayer();
            // Destroy this background
            Destroy(gameObject);
            // If a next portal is defined, activate it
            if (nextPortal != null)
            {
                nextPortal.SetActive(true);
            }
        }
    }
}
