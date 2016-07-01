using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PowerUpScript : MonoBehaviour {
    
    //Variables
    [SerializeField]
    private Text _powerupText;
    private int _randomNum;
    public string currPowerUp;
    private PlayerShooting _ps;
    private PlayerHealth _ph;
    public bool powerUp1 = false;
    public bool powerUp2 = false;
    public bool powerUp3 = false;
    public bool powerUp4 = false;
    public bool powerUp5 = false;

    //Gets Components
    void Start () {
        _ph = GetComponent<PlayerHealth>();
        _ps = GetComponent<PlayerShooting>();
    }
	//Updates the UI
	void Update () {
        UpdatepowerupUI();
    }
    //When collecting a pick-up it generates a random number and activates the powerUp() function.
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickUp"))
        {
            _randomNum = Random.Range(1, 6);
            PowerUp();
        }
    }
        //Activates power-up based on a random number.
    void PowerUp()
    {
        Debug.Log(_randomNum);
        powerUp1 = false;
        powerUp2 = false;
        powerUp3 = false;
        powerUp4 = false;
        powerUp5 = false;
        _ps.poweredUp = false;
        _ps._fireRate = 0.3f;
        if (_randomNum == 1)
        {
            currPowerUp = "BulletPower!";
            powerUp1 = true;
            _ps.poweredUp = true;
        }
        else if (_randomNum == 2)
        {
            currPowerUp = "Swiftness!";
            powerUp2 = true;           
        }
        else if (_randomNum == 3)
        {
            currPowerUp = "You Healed!";
            powerUp3 = true;
            _ph.Health += 250;
        }
        else if (_randomNum == 4)
        {
            currPowerUp = "Rapid Fire!";
            powerUp4 = true;
            _ps._fireRate = 0.2f;           
        }
        else if (_randomNum == 5)
        {
            powerUp5 = true;
            currPowerUp = "Regen Up!";
        }
    }
    //Updates the UI with the current power-up.
    private void UpdatepowerupUI()
    {
        _powerupText.text = "PowerUp = " + currPowerUp.ToString();
    }
}
