using System;
using System.Collections.Generic;
using UnityEngine.Events;

public class TypeCountHolder<T> : IUniqDataHolder<T>
{
    public UnityEvent<T> OnItemAdded { get; }

    private Dictionary<Type, int> _typeCountMap = new Dictionary<Type, int>();

    public TP Registration<TP>(TP item) where TP : T
    {
        Type type = item.GetType();

        if (IsExist(type))
            IncreaseValue(type, 1);
        else
            CreateKey(type);

        return item;
    }

    [Obsolete("This method is undesirable in this context. Use RemoveItems instead")]
    public TP Unregistration<TP>() where TP : T
    {
        if (!IsExist<TP>()) return default(TP);
        
        DecreaseValue(typeof(TP), 1);
        
        return default(TP);
    }
    
    public int RemoveItems<TP>(int count) where TP : T
    {
        Type type = typeof(TP);
        if (IsExist<TP>()) return -1;
        
        DecreaseValue(type, count);
        return _typeCountMap[type];
    }

    [Obsolete("This method is undesirable in this context. Use GetCountOfType instead")]
    public TP GetByType<TP>() where TP : T => 
        default(TP);
    
    public int GetCountOfType<TP>() where TP : T => 
        IsExist<TP>() ? _typeCountMap[typeof(TP)] : 0;

    public void ForEach(Action<T> action)
    {
        throw new NotImplementedException();
    }

    

    private void CreateKey(Type type) => 
        _typeCountMap[type] = 1;

    private void IncreaseValue(Type type, int added) =>
        _typeCountMap[type] += added;

    private void DecreaseValue(Type type, int subtrahend) =>
        _typeCountMap[type] = Math.Max(0, _typeCountMap[type] - subtrahend);

    private bool IsExist<TP>() where TP : T => 
        _typeCountMap.ContainsKey(typeof(TP));
    private bool IsExist(Type type)=> 
        _typeCountMap.ContainsKey(type);
}