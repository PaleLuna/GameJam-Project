using UnityEngine;
using UnityEngine.SceneManagement;

namespace ArtemYakubovich
{
    public class CameraController : MonoBehaviour, IStartable, IUpdatable
    {
        [SerializeField] private int _loadScene; 
        [SerializeField] private Camera _camera;
        [SerializeField] private LayerMask _layerMaskCurrent;
        
        private Vector3 _worldPointPos;



        public void OnStart()
        {
            ServiceLocator.Instance.Registarion(this);
            ServiceLocator.Instance.Get<GameController>().updatablesHolder.Registration(this);
        }

        public void EveryFrameRun()
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit, 50f,_layerMaskCurrent))
            {
                _worldPointPos = hit.point;
            }
        }
        
        public Vector3 GetMousePos()
        {
            return _worldPointPos;
        }
        public void LoadBattleScene() => 
            SceneManager.LoadScene(_loadScene);
    }
}

