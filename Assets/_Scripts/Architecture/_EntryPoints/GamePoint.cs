using System.Collections;
using UnityEngine;

public class GamePoint : MonoBehaviour
{
    private ServiceLocator _serviceLocator;

    [SerializeField, RequireInterface(typeof(IStartable))]
    private MonoBehaviour[] _startables;
    
    private IEnumerator Start()
    {
        _serviceLocator = ServiceLocator.Instance;

        if(_serviceLocator)
            GameSceneBoot();
        else
            GameBootStart();
        yield return null;
    }

    private void GameBootStart()
    {
        this.gameObject.AddComponent<BootPoint>();
    }

    private void GameSceneBoot()
    {
        _serviceLocator.Registarion(new InputService(new PCInput()));

        foreach (IStartable startable in _startables)
            startable.OnStart();
    }
}