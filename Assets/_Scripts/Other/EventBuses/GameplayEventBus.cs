using System;
using UnityEngine.Events;

public static class GameplayEventBus
{
    private static readonly UnityEvent<Item> _onItemCollect = new UnityEvent<Item>();
    private static readonly UnityEvent<Type> _onItemRemove = new UnityEvent<Type>();


    #region SubscribeMethods

    public static void SubscribeOnItemCollect(UnityAction<Item> action) =>
        _onItemCollect.AddListener(action);
    public static void SubscribeOnItemRemove(UnityAction<Type> action) =>
        _onItemRemove.AddListener(action);

    #endregion

    #region UnsubscribeMethods

    public static void UnsubscribeOnItemCollect(UnityAction<Item> action) =>
        _onItemCollect.RemoveListener(action);
    public static void UnsubscribeOnItemRemove(UnityAction<Type> action) =>
        _onItemRemove.RemoveListener(action);

    #endregion

    #region Invoke

    public static void OnItemCollect(Item item) =>
        _onItemCollect.Invoke(item);
    public static void OnItemRemove(Type item) =>
        _onItemRemove.Invoke(item);

    #endregion
}