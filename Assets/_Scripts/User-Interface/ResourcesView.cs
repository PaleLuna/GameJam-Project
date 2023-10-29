using System;
using TMPro;
using UnityEngine;

public class ResourcesView : MonoBehaviour, IStartable
{
    [SerializeField] private TMP_Text _woodCountText;
    [SerializeField] private TMP_Text _stoneCountText;
    [SerializeField] private TMP_Text _ropeCountText;

    private GameResources _gameResources;
    
    public void OnStart()
    {
        ResetCount();

        _gameResources = ServiceLocator.Instance.Get<GameResources>();
        
        GameplayEventBus.SubscribeOnItemCollect(UpdateCounter);
        GameplayEventBus.SubscribeOnItemRemove(UpdateCounter);
    }
    
    private void ResetCount()
    {
        _woodCountText.text = Convert.ToString(0);
        _stoneCountText.text = Convert.ToString(0);
        _ropeCountText.text = Convert.ToString(0);
    }

    private void UpdateCounter(Item item) => 
        UpdateCounter(item.GetType());

    private void UpdateCounter(Type type)
    {
        if(type == typeof(Woods))
            SetWoodCount();
        else if (type == typeof(Rock))
            SetRockCount();
        else if(type == typeof(Rope))
            SetRopeCount();
    }
    
    private void SetWoodCount()
    {
        _woodCountText.text = Convert.ToString(_gameResources.CheckCount<Woods>());
    }
    private void SetRockCount()
    {
        _stoneCountText.text = Convert.ToString(_gameResources.CheckCount<Rock>());
    }
    private void SetRopeCount()
    {
        _ropeCountText.text = Convert.ToString(_gameResources.CheckCount<Rope>());
    }
    
}
