using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    private ScoreManager _scoreManager;
    private float _speed = 35;
    //Destroys itself after 3 seconds.
    void Start()
    {
        _scoreManager = GameObject.FindGameObjectWithTag("sManager").GetComponent<ScoreManager>();
        Destroy(gameObject, 3f);
    }
    //Moves the projectile forward in a straight line.
    void Update()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
    }
    //Sets the speed of the projectile depending on the value.
    public void SetSpeed(float value)
    {
        _speed = value;
    }
    //Activates KillSelf() when colliding with an Enemy.
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            KillSelf();
        }
        else if (other.CompareTag("Mine"))
        {
            _scoreManager.score += 150;
            KillSelf();
            Destroy(other.gameObject);
        }
    }
    //Destroys itself on collision with an Enemy.
    void KillSelf()
    {
        Destroy(gameObject);
    }
}
