using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsFolower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2f;

    private void Start() {
        transform.position = waypoints[currentWaypointIndex].transform.position;
    }

    private void Update()
    {
        if (waypoints.Length !=0){
            if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
            {
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Length)
                {
                    currentWaypointIndex = 0;
                    Destroy(gameObject);
                }
            }
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, speed * Time.deltaTime);
        }
    }
}
