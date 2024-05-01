using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointInedx = 0;
    [SerializeField] private float speed  =5f;


    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointInedx].transform.position, transform.position) < .4f)
        {
            currentWaypointInedx++;
            if (currentWaypointInedx >= waypoints.Length) 
            {
                currentWaypointInedx = 0;
            }
        }
        transform.position = Vector2.MoveTowards (transform.position, waypoints[currentWaypointInedx].transform.position, Time.deltaTime * speed);
    }
}
