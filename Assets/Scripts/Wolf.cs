using System;
using TMPro;
using UnityEngine;

public class Wolf : Creature
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private ScoreCounter _counterOfEatenSheep = new ScoreCounter();

    private void Awake()
    {
        _transform = gameObject.GetComponent<Transform>();
        _rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Action();
    }

    protected override void Action()
    {
        if (Input.GetKey("w") || Input.GetKey("s"))
        {
            Move(Input.GetAxis("Vertical") * movementSpeed, transform.forward, _transform.position);
        }

        if (Input.GetKey("a") || Input.GetKey("d"))
        {
            Rotate();
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sheep"))
        {
            Destroy(collision.gameObject);
            _counterOfEatenSheep.scoreCountNumber += 1;
        }
    }

    private void Rotate()
    {
        _rigidbody.MoveRotation(
            Quaternion.Euler(Input.GetAxis("Horizontal") * Time.fixedDeltaTime * rotationSpeed * Vector3.up) *
            _rigidbody.rotation);
    }
}