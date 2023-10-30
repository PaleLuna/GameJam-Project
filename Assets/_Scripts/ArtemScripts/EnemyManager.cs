using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArtemYakubovich
{
    public class EnemyManager : MonoBehaviour, IStartable, IUpdatable
    {
        [Header("RespanParams")]
        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private float _timeToRespawn;
        private Queue<Enemy> _enemyToRespawn;
        private float _currentTime = 0;

        [Header("EnemyList")]
        [SerializeField] private Enemy[] _enemies;
        
        [Header("TargetForAllEnemies")]
        [SerializeField] private Transform _transformTarget;

        public void OnStart()
        {
            ServiceLocator.Instance
                .Get<GameController>()
                .updatablesHolder.Registration(this);
            
            for (int i = 0; i < _enemies.Length; i++)
                RespawnEnemy(_enemies[i]);
            
            GameplayEventBus.SubscribeOnEnemyDeath(AddToRespawnQueue);
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

        private void AddToRespawnQueue(Enemy enemy) =>
            _enemyToRespawn.Enqueue(enemy);

        public void EveryFrameRun()
        {
            _currentTime += Time.deltaTime;

            if (_currentTime < _timeToRespawn) return;
            
            print(_currentTime);
            RespawnEnemy(GetEnemyFromQueue());
            _currentTime -= _timeToRespawn;
        }

        private void RespawnEnemy(Enemy enemy)
        {
            if(enemy == null) return;
            
            int spawnId = Random.Range(0, spawnPoints.Length);

            Vector3 spawnPoint = spawnPoints[spawnId].position;

            float diff = 2F;

            spawnPoint = new Vector3(
                Random.Range(spawnPoint.x - diff, spawnPoint.x + diff),
                spawnPoint.y,
                Random.Range(spawnPoint.z - diff, spawnPoint.z + diff));
            enemy.transform.position = spawnPoints[spawnId].position;
            
            enemy.gameObject.SetActive(true);
            enemy.SetTarget(_transformTarget);
        }

        private Enemy GetEnemyFromQueue()
        {
            if(_enemyToRespawn.Count <= 0) return null;
           return _enemyToRespawn.Dequeue();
        }
    }
}
