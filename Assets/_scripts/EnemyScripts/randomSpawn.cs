using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class randomSpawn : MonoBehaviour {

    public GameObject pickUp;
    private float _i;
    [SerializeField]
    private Transform[] _wayPoints;
    [SerializeField]
    private int _waypointIndex;
    //Sets counter i at 0
    void Start()
    {
        _i = 0;
    }
	// Counts to 10 and then spawns activates Spawn()
	void Update ()
    {
        if (_i < Time.time)
        {
            _i = Time.time + 10f;
            Spawn();
        }
    }
    //Spawns a pick-up at a random location
    void Spawn ()
    {
            _waypointIndex = Random.Range(0, _wayPoints.Length);
            PickUps square  = Instantiate(pickUp, _wayPoints[_waypointIndex].position, _wayPoints[_waypointIndex].rotation) as PickUps;
    }
}
