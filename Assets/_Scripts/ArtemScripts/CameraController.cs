using UnityEngine;
using UnityEngine.SceneManagement;

namespace ArtemYakubovich
{
    public class CameraController : MonoBehaviour
    {
        private Camera _camera;
        private Vector3 _worldPointPos;
        [SerializeField] private LayerMask _layerMaskCurrent;

        public Vector3 GetMousePos()
        {
            return _worldPointPos;
        }
        
        private void Start()
        {
            _camera = GetComponent<Camera>();
        }

        private void Update()
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit, 50f,_layerMaskCurrent))
            {
                _worldPointPos = hit.point;
            }
        }

        public void LoadBattleScene()
        {
            SceneManager.LoadScene(2);
        }
    }
}

