using UnityEngine;

namespace ArtemYakubovich
{
    public class TowersManager : MonoBehaviour, IStartable
    {
        [SerializeField] private Transform[] _towersPosition;
        [SerializeField] private GameObject _tower;

        public void OnStart()
        {
            for (int i = 0; i < _towersPosition.Length; i++)
            {
                GameObject tmp = Instantiate(_tower);
                tmp.transform.position = _towersPosition[i].position;
            }
        }

        public Transform[] GetPositions()
        {
            return _towersPosition;
        }

        
    }
}
