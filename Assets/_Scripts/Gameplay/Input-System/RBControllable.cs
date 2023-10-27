using UnityEngine;

public class RBControllable : IControllable
{
    private const float _angle = 90F;
    
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
        Vector3 rotate = _currentDirection * _angle;
        
        velocity = Vector3.ClampMagnitude(velocity, speed);
        
        velocity.y = _rigidbody.velocity.y;
        _rigidbody.velocity = velocity;
        _rigidbody.rotation = Quaternion.Euler(rotate);
    }

    public void Interaction()
    {
        throw new System.NotImplementedException();
    }

    private void SetDirection(Vector3 direction) => 
        _currentDirection = direction;
}