using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArtemYakubovich
{
    public class EnemyManager : MonoBehaviour, IStartable, IUpdatable
    {
        [SerializeField] private Enemy[] _enemies;
        [SerializeField] private Transform _transformTarget;
        
        public void OnStart()
        {
            ServiceLocator.Instance.Get<GameController>().updatablesHolder.Registration(this);
            for (int i = 0; i < _enemies.Length; i++)
            {
                _enemies[i].SetTarget(_transformTarget);
                _enemies[i].OnStart();
            }
        }
    
        public void EveryFrameRun()
        {  
            
        }
        
        public Enemy GetEnemy(Vector3 point)
        {
            float minDistance = Mathf.Infinity;
            Enemy closestEnemy = null;
            for (int i = 0; i < _enemies.Length; i++)
            {
                float distance = Vector3.Distance(point, _enemies[i].transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestEnemy = _enemies[i];
                }
            }

            return closestEnemy;
        }
    }
}
