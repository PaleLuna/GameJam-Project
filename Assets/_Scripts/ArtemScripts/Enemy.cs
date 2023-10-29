using System;
using UnityEngine;
using UnityEngine.AI;

namespace ArtemYakubovich
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private int _health;
        private Transform _target;

        private void OnValidate()
        {
            _navMeshAgent ??= GetComponent<NavMeshAgent>();
        }

        public void SetTarget(Transform target)
        {
            _target = target;
            _navMeshAgent.destination = target.position;
        }
        

    }
}
