using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool _thrusting;
    private float _turnDirection;
    private Rigidbody2D _rigidbody;

    public float thrustSpeed = 1.0f;
    public float turnSpeed = 1.0f;

    // Initialization work
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _thrusting = (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow));

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            _turnDirection = 1.0f;

        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            _turnDirection = -1.0f;

        else
            _turnDirection = 0;
    }


    private void FixedUpdate()
    {
        if (_thrusting)
        {
            _rigidbody.AddForce(this.transform.up * this.thrustSpeed); // forward
        }

        if (_turnDirection != 0)
        {
            _rigidbody.AddTorque(_turnDirection * this.turnSpeed);
        }
    }

}
