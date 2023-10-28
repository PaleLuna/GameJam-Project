using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace ArtemYakubovich
{
    public enum TowerState
    {
        Active,
        Table
    }

    public class Tower : MonoBehaviour, IStartable, IUpdatable
    {
        [SerializeField] private float _distance;
        [SerializeField] private float _timerForShoot;
        [SerializeField] private Bullet _bullet;
        [SerializeField] private Transform _shootPosition;
        
        private float _timer = 0;
        public EnemyManager EnemyManager;
        private CameraController _cameraController;
        private TowerState _towerState;
        private bool _isFindPlace;
        private Vector3 _mousePos;
        
        private void Start()
        {
            OnStart();
        }

        public void OnStart()
        {
            _towerState = TowerState.Active;
            
            _cameraController = ServiceLocator.Instance.Get<CameraController>();
            ServiceLocator.Instance.Get<GameController>().updatablesHolder.Registration(this);
        }

        public void EveryFrameRun()
        {
            if (_isFindPlace)
            {
                _mousePos = _cameraController.GetMousePos();
                Vector3 pos = new Vector3(_mousePos.x, 1, _mousePos.z);
                transform.position = pos;
                if (Input.GetMouseButtonUp(0))
                {
                    _isFindPlace = false;
                }
            }
            else if(_towerState == TowerState.Active)
            {
                if (!EnemyManager.GetEnemy(transform.position)) return;
                
                Enemy enemy = EnemyManager.GetEnemy(transform.position);
                Vector3 position = enemy.transform.position;
                Vector3 positionXZ = new Vector3(position.x, 1f, position.z);
                
                if (Vector3.Distance(transform.position, positionXZ) < _distance)
                {
                    transform.LookAt(positionXZ);
                    TryToShoot(enemy);
                }
            }
        }

        private void OnMouseDown()
        {
            if (_towerState == TowerState.Table)
                _isFindPlace = true;
        }

        private void TryToShoot(Enemy enemy)
        {
            _timer += Time.deltaTime;
            if (_timer > _timerForShoot)
            {
                _timer = 0;
                Bullet tmpBullet = Instantiate(_bullet, _shootPosition.position, Quaternion.identity);
                tmpBullet.SetTarget(enemy);
            }
        }
    }
}
