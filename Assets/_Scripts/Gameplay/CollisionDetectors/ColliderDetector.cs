using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColliderDetector : MonoBehaviour, ICollisionDetecter
{
    #region UnityEvents

    private UnityEvent<Collision> _onColliderEnter = new UnityEvent<Collision>();
    private UnityEvent<Collision> _onColliderExit = new UnityEvent<Collision>();
    private UnityEvent<Collision> _onColliderStay = new UnityEvent<Collision>();

    #endregion

    #region Properties

    [SerializeField] private LayerMask _colliserMask;
    private List<GameObject> _currentCollisions = new List<GameObject>();

    #endregion
    
    #region Getters

    public UnityEvent<Collision> onColliderEnter => _onColliderEnter;
    public UnityEvent<Collision> onColliderExit => _onColliderExit;
    public UnityEvent<Collision> onColliderStay => _onColliderStay;

    public IEnumerable<GameObject> currentCollisions => _currentCollisions;

    #endregion
    
    public T[] FindAroundByType<T>(float searchRadius) where T : Component
    {
        List<T> colliderWithReqComponent = new List<T>();
        Collider[] allCollidersAround = Physics.OverlapSphere(transform.position, searchRadius, _colliserMask);
        
        foreach (Collider collider in allCollidersAround)
        {
            T component = collider.GetComponent<T>();
            if(component)
                colliderWithReqComponent.Add(component);
        }

        return colliderWithReqComponent.ToArray();
    }

    private void OnCollisionEnter(Collision other)
    {
        _currentCollisions.Add(other.gameObject);
        onColliderEnter.Invoke(other);
    }

    private void OnCollisionExit(Collision other)
    {
        _currentCollisions.Remove(other.gameObject);
        onColliderExit.Invoke(other);
    }
}