using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface ICollisionDetecter
{
    UnityEvent<Collision> onColliderEnter { get; }
    UnityEvent<Collision> onColliderExit { get; }

    public IEnumerable<GameObject> currentCollisions { get; }

    public T[] FindAroundByType<T>(float searchRadius) where T : Component;
}
