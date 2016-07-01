using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    // Use this for initialization
    private PowerUpScript _pus;
    [SerializeField]
    private Text _healthText;                              // UI Text element
    public float Health;                                  // The current health the player has.
    private float _counter;                                // Timer

    void Start () {
        _pus = gameObject.GetComponent<PowerUpScript>();    //Power-up script for the regen power-up.
        Health = 1000;                                      // Maximum Health
        _counter = 0;                                        // Timer to 0 on start
	}
	// Updates HealthUI and creates a regen counter. Manages MaxHealth and kills player if it reaches 0hp.
	void Update () {
        
        UpdateHealthUI();

        if (Health <= 750 && _counter < Time.time)
        {
            _counter = Time.time + 1f;
            regen();
        }

        if (Health >= 1000)
        {
            Health = 1000;
        }
        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    //Gets activated in Update; Updates the UI text to current health
    private void UpdateHealthUI()
    {
        _healthText.text = "Health:" + Health.ToString();
    }
    //Taking damage from Mines and Bulletse e
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mine"))
        { 
            Health -= 500;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("EnemyBullet"))
        {
            Health -= 80;
        }
    }
    //Regenerates health over time
    void regen()
    {
        if (_pus.powerUp5 == true)
        {
            Health += 25;
        }
        else
        {
            Health += 12;
        }
    }
}
