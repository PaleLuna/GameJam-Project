using UnityEngine;

namespace ArtemYakubovich
{
    public class Enemy : MonoBehaviour, IStartable, IUpdatable
    {
        [SerializeField] private int _health;
        [SerializeField] private float _speed;
        private Transform _target;

        public void SetTarget(Transform target)
        {
            _target = target;
        }
        
        public void OnStart()
        {
            ServiceLocator.Instance.Get<GameController>().updatablesHolder.Registration(this);
        }
    
        public void EveryFrameRun()
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
        }
    }
}
