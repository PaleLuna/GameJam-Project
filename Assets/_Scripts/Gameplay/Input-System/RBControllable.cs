using UnityEngine;

public class RBControllable : IControllable
{
    private Rigidbody _rigidbody;
    private Vector3 _currentDirection;

    public RBControllable(Rigidbody rigidbody)
    {
        _rigidbody = rigidbody;
        
        GameplayInputEventBus.SubscribeOnGetDirection(SetDirection);
    }

    public void Move(float speed)
    {
        Vector3 velocity = _currentDirection * speed;

        velocity = Vector3.ClampMagnitude(velocity, speed);
        
        velocity.y = _rigidbody.velocity.y;
        _rigidbody.velocity = velocity;
    }

    public void Interaction()
    {
        throw new System.NotImplementedException();
    }

    private void SetDirection(Vector3 direction) => 
        _currentDirection = direction;
}