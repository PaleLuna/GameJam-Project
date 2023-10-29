using UnityEngine;

public class RBControllable : IControllable
{
    private Rigidbody _rigidbody;
    private ICollisionDetecter _collisionDetecter;
    
    private Vector3 _currentDirection;

    public RBControllable(Rigidbody rigidbody, Player player)
    {
        _rigidbody = rigidbody;
        _collisionDetecter = player.CollisionDetecter;
        
        GameplayInputEventBus.SubscribeOnGetDirection(SetDirection);
        GameplayInputEventBus.SubscribeOnInteract(Interaction);
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
        Debug.Log("Interact!");
        Item[] items = _collisionDetecter.FindAroundByType<Item>(1.0F);

        foreach (Item item in items)
            item.Collect();
    }

    private void SetDirection(Vector3 direction) => 
        _currentDirection = direction;
}