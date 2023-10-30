using System;
using ArtemYakubovich;
using UnityEngine.Events;

public static class GameplayEventBus
{
    private static readonly UnityEvent<Item> _onItemCollect = new UnityEvent<Item>();
    private static readonly UnityEvent<Type> _onItemRemove = new UnityEvent<Type>();

    private static readonly UnityEvent<Enemy> _onEnemyDeath = new UnityEvent<Enemy>();


    #region SubscribeMethods

    public static void SubscribeOnItemCollect(UnityAction<Item> action) =>
        _onItemCollect.AddListener(action);
    public static void SubscribeOnItemRemove(UnityAction<Type> action) =>
        _onItemRemove.AddListener(action);
    public static void SubscribeOnEnemyDeath(UnityAction<Enemy> action) =>
        _onEnemyDeath.AddListener(action);

    #endregion

    #region UnsubscribeMethods

    public static void UnsubscribeOnItemCollect(UnityAction<Item> action) =>
        _onItemCollect.RemoveListener(action);
    public static void UnsubscribeOnItemRemove(UnityAction<Type> action) =>
        _onItemRemove.RemoveListener(action);
    
    public static void UnsubscribeOnEnemyDeath(UnityAction<Enemy> action) =>
        _onEnemyDeath.RemoveListener(action);

    #endregion

    #region Invoke

    public static void OnItemCollect(Item item) =>
        _onItemCollect.Invoke(item);
    public static void OnItemRemove(Type item) =>
        _onItemRemove.Invoke(item);
    public static void OnEnemyDeath(Enemy enemy) =>
        _onEnemyDeath.Invoke(enemy);

    #endregion
}