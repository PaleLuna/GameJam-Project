using System;
using UnityEngine;

namespace ArtemYakubovich
{
    public class Bullet : MonoBehaviour, IUpdatable
    {
        [SerializeField] private Enemy _target;
        [SerializeField] private float _speed;

        public void SetTarget(Enemy enemy) => 
            _target = enemy;

        private void OnTriggerEnter(Collider other) => 
            Destroy(gameObject);

        private void Start() => 
            ServiceLocator.Instance.Get<GameController>().updatablesHolder.Registration(this);

        public void EveryFrameRun() => 
            transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);

        private void OnDestroy() => 
            ServiceLocator.Instance?.Get<GameController>()?.updatablesHolder?.UnRegistration(this);
    }
}