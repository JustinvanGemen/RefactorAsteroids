using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour {
    [SerializeField]
    private EnemyProjectile _enemyProjectile;
    [SerializeField]
    private Transform _muzzle;
    public float _bulletSpeed = 10;
    private float _delayCounter = 0.0F;
    private float _fireRate = 1F;
    private GameObject _Player;
    private Transform _player;
    [SerializeField]
    private Transform _target;
    private bool _shooting;
    public float range;
    public float seeRange;
    public bool inRange;

    //Puts the inRange Boolean on false.
	void Start ()
    {
        inRange = false;
    }
    //Finds the player.
	void Awake ()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
	}
    //Traces if the player is close enough to shoot at the player and shoots if this is the case.
    void Update()
    {        
        _delayCounter -= Time.deltaTime;
    
        if(Vector3.Distance (transform.position, _target.position) < range)
        {
            inRange = true;
        }
        else
        {
            inRange = false;
        }   
        if (inRange == true && _delayCounter <= Time.deltaTime)
        {
            transform.LookAt(_player.position);
            Shoot();
        }
    }
    //Spawns a projectile 
    void Shoot()
    {        
        _shooting = true;
        EnemyProjectile bullet = Instantiate(_enemyProjectile, _muzzle.position, _muzzle.rotation) as EnemyProjectile;
        bullet.SetSpeed(_bulletSpeed);
        _delayCounter = Time.deltaTime + _fireRate;
    }
}
