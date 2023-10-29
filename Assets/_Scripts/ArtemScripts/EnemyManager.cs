using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArtemYakubovich
{
    public class EnemyManager : MonoBehaviour, IStartable
    {
        [SerializeField] private Enemy[] _enemies;
        [SerializeField] private Transform _transformTarget;
        
        public void OnStart()
        {
            for (int i = 0; i < _enemies.Length; i++)
            {
                _enemies[i].SetTarget(_transformTarget);
                
                print(_transformTarget.position);
            }
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
