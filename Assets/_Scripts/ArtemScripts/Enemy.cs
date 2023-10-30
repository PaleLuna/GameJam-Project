using System;
using UnityEngine;
using UnityEngine.AI;

namespace ArtemYakubovich
{
    public class Enemy : MonoBehaviour, IDamagable
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


        public void GetDamage(int damage)
        {
            _health = Math.Max(_health - damage, 0);
            
            if(_health != 0) return;
            
            GameplayEventBus.OnEnemyDeath(this);
            gameObject.SetActive(false);
        }
    }
}
