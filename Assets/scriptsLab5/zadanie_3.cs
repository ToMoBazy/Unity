using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformaPoruszajacaSie : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] List<Transform> waypoints = new List<Transform>();

    private int currentWaypointIndex = 0;
    private bool isMovingForward = true;
    private bool isPlayerOnPlatform = false;
    private Transform player;

    void Update()
    {
        

        if (isPlayerOnPlatform)
        {
            MovePlatform();
        }
    }

    void MovePlatform()
    {
        if (waypoints.Count == 0)
        {
            Debug.LogWarning("Brak waypointów. Dodaj waypointy poprzez panel Inspektora.");
            return;
        }

        Transform targetWaypoint = waypoints[currentWaypointIndex];

       
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

      
        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            
            if (currentWaypointIndex == waypoints.Count - 1)
            {
                isMovingForward = false;
            }
            
            else if (currentWaypointIndex == 0)
            {
                isMovingForward = true;
            }

           
            currentWaypointIndex += isMovingForward ? 1 : -1;
        }
    }



    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerOnPlatform = true;
            player = other.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerOnPlatform = false;
            player = null;
        }
    }
}