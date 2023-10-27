using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArtemYakubovich
{
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField] private Enemy[] _enemies;

        void Start()
        {

        }

        void Update()
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
