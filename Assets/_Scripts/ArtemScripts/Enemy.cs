using UnityEngine;
using UnityEngine.AI;

namespace ArtemYakubovich
{
    public class Enemy : MonoBehaviour, IStartable, IUpdatable
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private int _health;
        private Transform _target;

        public void SetTarget(Transform target)
        {
            _target = target;
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }
        
        public void OnStart()
        {
            ServiceLocator.Instance.Get<GameController>().updatablesHolder.Registration(this);
            _navMeshAgent.SetDestination(_target.position);
            print(_target.position);
        }
    
        public void EveryFrameRun()
        {
           
        }
    }
}
