using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    [SerializeField] List <Transform> waypoints;

    float enemySpeed = 2f;

    int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
    }

    private void EnemyMovement()
    {
        if(waypointIndex < waypoints.Count)
        {
            //set targetPosition to the next waypoint
            Vector3 targetPosition = waypoints[waypointIndex].transform.position;

            targetPosition.z = 0f;

            float movementThisFrame = enemySpeed * Time.deltaTime;
            
            //move the enemy ship from the current position towards the targePosition at the given movement speed
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementThisFrame);

            //if we reached the waypoint
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }


        }
        //if enemy reaches the last waypoint
        else
        {
            Destroy(gameObject);
        }
    }
}
