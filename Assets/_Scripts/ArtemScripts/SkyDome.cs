using UnityEngine;

namespace ArtemYakubovich
{
    
    public class SkyDome : MonoBehaviour, IStartable, IUpdatable
    {
        [SerializeField] private float _speed;
    
        public void OnStart()
        {
            ServiceLocator.Instance.Get<GameController>().updatablesHolder.Registration(this);
        }
    
        public void EveryFrameRun()
        {  
            transform.Rotate(Vector3.up, _speed * Time.deltaTime);
        }
    }
}