using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public GameObject _enemy;
    public Transform _spawner;
    [SerializeField]
    private int _time;
    [SerializeField]
    private int _repeatRate;

	// Activates Spawn() 
	void Start () {
        InvokeRepeating("Spawn", _time, _repeatRate);
	}
	// Spawns an Enemy
	void Spawn () {
        Instantiate(_enemy, _spawner.position, _spawner.rotation);
	}
}
