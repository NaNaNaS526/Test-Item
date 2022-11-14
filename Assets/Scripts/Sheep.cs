using UnityEngine;
using Random = UnityEngine.Random;

public class Sheep : Creature
{
    private bool _isAfraid;
    private Transform _wolfTransform;
    private float _distanceToWolf;
    private Vector3 _randomPosition;
    [SerializeField] private float nextChangeDirectionTime;

    private void Awake()
    {
        _wolfTransform = GameObject.FindGameObjectWithTag("Wolf").GetComponent<Transform>();
        _transform = gameObject.GetComponent<Transform>();
        _rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _distanceToWolf = (_wolfTransform.position - transform.position).magnitude;
        if (_distanceToWolf <= 2f)
        {
            _isAfraid = true;
        }

        Action();
    }

    protected override void Action()
    {
        if (_isAfraid)
        {
            Vector3 direction = transform.position - _wolfTransform.position;
            Move(movementSpeed, direction, _transform.position);
            transform.LookAt(direction);
            if (_distanceToWolf >= 4f)
                _isAfraid = false;
        }

        else
        {
            if (Time.time % nextChangeDirectionTime == 0)
            {
                _randomPosition = new Vector3(Random.Range(-20f, 20f), 0.25f, Random.Range(-20f, 20f));
            }

            Move(movementSpeed * 0.1f, _randomPosition, _transform.position);
            transform.LookAt(_randomPosition);
        }
    }
}