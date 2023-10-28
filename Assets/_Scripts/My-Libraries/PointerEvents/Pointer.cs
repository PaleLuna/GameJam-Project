using UnityEngine;
using UnityEngine.Events;
using CameraController = ArtemYakubovich.CameraController;

namespace PaleLuna.PointEvents
{
    public class Pointer : MonoBehaviour, IPointer, IFixedUpdatable, IStartable
    {
        [SerializeField] private DataHolder<Rigidbody> _rigidBodyHolder;
        [SerializeField] private Transform _maskTransform;

        private CameraController _cameraController;

        private UnityEvent<Vector3> onClick = new UnityEvent<Vector3>();

        public void onPointCliclSubscribe(UnityAction<Vector3> action) => 
            onClick.AddListener(action);

        public void onPointClickUnsubscribe(UnityAction<Vector3> action) => 
            onClick.RemoveListener(action);

        public void FollowThePointer(GameObject obj)
        {
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            if(!rb) return;

            _rigidBodyHolder.Registration(rb);
        }

        public void CreateMassageOnClick(string msg)
        {
            throw new System.NotImplementedException();
        }

        public void FixedFrameRun()
        {
            MoveMask();
        }

        private void MoveMask()
        {
            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _maskTransform.position.z);
            Vector3 pos = _cameraController.Camera.ScreenToWorldPoint(mousePos);

            pos.z = _maskTransform.position.z;
            _maskTransform.position = pos;
        }

        public void OnStart()
        {
            _cameraController = ServiceLocator.Instance.Get<CameraController>();
            ServiceLocator.Instance.Get<GameController>().updatablesHolder.Registration(this);
        }
    }
}