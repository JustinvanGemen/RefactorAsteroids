using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MovementPlayer : MonoBehaviour
{
    private PowerUpScript _pus;
    private float _counter;
    private float _X = 0;
    private float _Y = 0;
    private float _Z = 0;
    private float _speedF = 0;
    private float _speedB = 0;
    private float _rotationR = 0;
    private float _rotationL = 0;
    private float _speedFmax = 20f;
    private float _speedBmax = 20f;
    private float _rotateLmax = 50f;
    private float _rotateRmax = 50f;
    private float _rotateL = 50f;
    private float _rotateR = 50f;
    private float _moveF = 0.4f;
    private float _moveB = 0.4f;
    private Rigidbody _rb;

    //Gets components and sets counter at 0
    void Start()
    {
        _pus = GetComponent<PowerUpScript>();
        _rb = GetComponent<Rigidbody>();
        this.transform.position = new Vector3(_X, _Y, _Z);
        _counter = 0;
    }
    //Handles keyboard input to make the player move and rotate
    void Update()
    {
        //Swiftness
        if (_pus.powerUp2 == true)
        {
            _speedFmax = 30f;
            _speedBmax = 30f;
            _rotateLmax = 70f;
            _rotateRmax = 70f;
        }
        else
        {
            _speedFmax = 20f;
            _speedBmax = 20f;
            _rotateRmax = 50f;
            _rotateRmax = 50f;
        }
        //MOVE FORWARD
        if (Input.GetKey(KeyCode.W))
        {
            if (_speedF < _speedFmax)
            {
                _speedF += _moveF;         
            }
        }
        else
        {
            if (_speedF > 0.4f)
            {
                _speedF -= _moveF;
            }
        }
        //ROTATE TO LEFT
        if (Input.GetKey(KeyCode.A))
        {
            _rotationL = _rotateL;
        }
        else
        {
            _rotationL = 0f;
        }
        //MOVE BACKWARDS
        if (Input.GetKey(KeyCode.S))
        {
            if (_speedB < 20)
            {
                _speedB += _moveB;
            }
        }
        else
        {
            if (_speedB > 0.4f)
            {
                _speedB -= _moveB;
            }
        }
        //ROTATE TO RIGHT
        if (Input.GetKey(KeyCode.D))
        {
            _rotationR = _rotateR;
        }
        else
        {
            _rotationR = 0f;
        }
    }
    //Moves and rotates according to the input given in Update()
    void FixedUpdate()
    {
        float rotation = _rotationR - _rotationL;
        float speed = _speedF - _speedB;
        _rb.MovePosition(_rb.position + (transform.TransformDirection(Vector3.forward) * speed * Time.fixedDeltaTime));
        _rb.MoveRotation(_rb.rotation * Quaternion.Euler(Vector3.up * rotation * Time.fixedDeltaTime));
    }
}