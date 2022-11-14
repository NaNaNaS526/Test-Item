using UnityEngine;

public abstract class Creature : MonoBehaviour
{
    [SerializeField] protected float movementSpeed;
    protected Rigidbody _rigidbody;
    protected Transform _transform;

    protected abstract void Action();

    protected void Move(float speed, Vector3 targetposition, Vector3 position)
    {
        _rigidbody.MovePosition(speed * Time.fixedDeltaTime * targetposition + position);
    }
}