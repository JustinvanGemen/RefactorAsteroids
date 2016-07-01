using UnityEngine;
using System.Collections;

public class EnemyProjectile : MonoBehaviour {
    //Variable for the speed of the projectile and a variable for the PlayerHealth component.
    private float _speed = 1;
    private PlayerHealth _ph;
    // Destroys the bullet 15 seconds after shooting. Also finds the PlayerHealth component on the Player.
    void Start () {
        _ph = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerHealth> ();
        Destroy(gameObject, 4f);
	}
	// Update function moves the projectile in a straight line. Speed depends on SetSpeed()
	void Update () {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
	}
    //Speed variable equals a value that determines how fast the projectile moves.
    public void SetSpeed(float value)
    {
        _speed = value;
    }
    //On collision with player destroy this object.
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag ("Player"))
        {
			Destroy (this.gameObject);
        }
    }
}
