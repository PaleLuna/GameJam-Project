using UnityEngine;

namespace ArtemYakubovich
{
    public class TowersManager : MonoBehaviour, IStartable
    {
        [SerializeField] private EnemyManager _enemyManager;
        [SerializeField] private Transform[] _towersPosition;
        [SerializeField] private GameObject _tower;

        public void OnStart()
        {
            for (int i = 0; i < _towersPosition.Length; i++)
            {
                GameObject tmp = Instantiate(_tower);
                tmp.transform.position = _towersPosition[i].position;
                tmp.transform.GetComponent<Tower>().EnemyManager = _enemyManager;
            }
        }
        public Transform[] GetPositions() => _towersPosition;
    }
}
