using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArtemYakubovich
{
    public class Bullet : MonoBehaviour, IStartable, IUpdatable
    {
        [SerializeField] private Enemy _target;
        [SerializeField] private float _speed;

        public void SetTarget(Enemy enemy)
        {
            _target = enemy;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            Destroy(gameObject);
        }

        public void OnStart()
        {
            ServiceLocator.Instance.Get<GameController>().updatablesHolder.Registration(this);
        }

        public void EveryFrameRun()
        {
            
        }


        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);
        }
    }

}