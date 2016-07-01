using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
    [SerializeField]
    private float _eHealth = 100;
    private ScoreManager _scoreManager;

    //Finds the Score Manager
    void Awake ()
    {
        _scoreManager = GameObject.FindGameObjectWithTag("sManager").GetComponent<ScoreManager>();
    }
    //Destroys the Enemy 180 seconds after spawning
    void Start () {
        Destroy(gameObject, 180f);
    }
    //When the Enemy's health reaches 0 it destroys itself and gives points to the player.
    void Update () {
        if(_eHealth == 0)
        {
            _scoreManager.score += 150;
            Destroy(gameObject);
        }     
    }
    //When colliding with a playerBullet, lose 10 health.
    void OnTriggerEnter(Collider other)
    {
       if (other.CompareTag("playerBullet"))
       {
            _eHealth -= 10;
            Destroy(other.gameObject);
        }

    }
}
