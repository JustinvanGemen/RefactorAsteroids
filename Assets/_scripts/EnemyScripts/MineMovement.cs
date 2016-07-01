using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MineMovement : MonoBehaviour
{
    [SerializeField]
    private Transform[] _wayPoints;
    private int _waypointIndex;
    private NavMeshAgent _nav;
    private float _speed = 5f;

    //Gets the nav mesh component
    void Awake()
    {
        _nav = GetComponent<NavMeshAgent>();
    }
    //Activates move()
    void Update()
    {
        move();
    }
    //Moves towards a random waypoint
    void move()
    {
        _nav.speed = _speed;
            if (_nav.remainingDistance < 0.5)
            {
                _waypointIndex = Random.Range(0, _wayPoints.Length);
            }
            _nav.SetDestination(_wayPoints[_waypointIndex].position);
    }
    //Kills itself when moving into a bullet
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("playerBullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

    }
}
