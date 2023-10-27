using PaleLuna.Math;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerLookForward
{
    private Transform _transform;
    private Vector3 _currentDirection;

    public PlayerLookForward(Transform transform)
    {
        _transform = transform;
        GameplayInputEventBus.SubscribeOnGetDirection(SetCurrentDirection);
    }

    private void Rotate()
    {
        float angle = CustomMath.DirectionToAngle(_currentDirection, Vector3.up);

        Quaternion targetRotation = Quaternion.Euler(0, angle, 0);
        
        _transform.rotation = targetRotation;
    }

    private void SetCurrentDirection(Vector3 direction)
    {
        if(_currentDirection.Equals(direction) || direction.Equals(Vector3.zero)) return;

        _currentDirection = direction;
        Rotate();
    }
}