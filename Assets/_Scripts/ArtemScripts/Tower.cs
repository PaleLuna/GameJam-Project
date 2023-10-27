using System;
using UnityEngine;

namespace ArtemYakubovich
{
    public enum TowerState
    {
        Active,
        Table
    }

    public class Tower : MonoBehaviour, IStartable, IUpdatable
    {
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
            _towerState = TowerState.Table;
            
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
        }

        private void OnMouseDown()
        {
            if (_towerState == TowerState.Table)
                _isFindPlace = true;
        }
    }
}
