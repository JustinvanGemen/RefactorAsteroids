using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomMovement : MonoBehaviour
{
    [SerializeField]
    private Transform[] wayPoints;
    private int waypointIndex;
    private Transform player;
    private NavMeshAgent nav;
    private float speed = 5f;
    private EnemyShooting es;
    //Gets certain components and finds the player
    void Awake()
    {
        es = GetComponent<EnemyShooting>();
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    //Activates move()
    void Update()
    {
        move();
    }
    //Moves to a random waypoint unless player is inRange, if the player is inRange it will move towards the player instead.
    void move()
    {
        nav.speed = speed;
        if (es.inRange == false)
        {
            if (nav.remainingDistance < 0.5)
            {
                waypointIndex = Random.Range(0, wayPoints.Length);
            }
            nav.SetDestination(wayPoints[waypointIndex].position);
        }
        else if(es.inRange == true)
        {
            nav.SetDestination(player.position);
        }
    }
}
