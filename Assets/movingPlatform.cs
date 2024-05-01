using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform[] waypoints;   // Array of waypoints the platform will move between
    public float moveSpeed = 2f;    // Speed of the platform
    public bool loop = true;        // Whether the platform should loop through waypoints

    private int currentWaypointIndex = 0;
    private Vector3 targetPosition;
    private Rigidbody2D playerRb;
    void Start()
    {
        SetTargetPosition();
    }

    void Update()
    {
        MovePlatform();

        // If the platform has reached its current target waypoint, set the next target
        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                if (loop)
                    currentWaypointIndex = 0; // Reset to the first waypoint if looping
                else
                    return; // If not looping, stop moving
            }
            SetTargetPosition();
        }
    }

    void MovePlatform()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    void SetTargetPosition()
    {
        targetPosition = waypoints[currentWaypointIndex].position;
    }

    // Ensure the player sticks to the platform and set its speed to 14
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = transform;
            collision.gameObject.GetComponent<Player>().speed = 20;
            //collision.collider.transform.SetParent(transform);
            //Rigidbody2D playerRb = collision.collider.GetComponent<Rigidbody2D>();
            //playerRb.velocity = new Vector2(14f, playerRb.velocity.y);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = null;
            collision.gameObject.GetComponent<Player>().speed = 5;
            //collision.collider.transform.SetParent(null);
        }
    }
}





