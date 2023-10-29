using UnityEngine.Events;

public static class GameplayEventBus
{
    private static readonly UnityEvent<Item> _onItemCollect = new UnityEvent<Item>();


    #region SubscribeMethods

    public static void SubscribeOnItemCollect(UnityAction<Item> action) =>
        _onItemCollect.AddListener(action);

    #endregion

    #region UnsubscribeMethods

    public static void UnsubscribeOnItemCollect(UnityAction<Item> action) =>
        _onItemCollect.RemoveListener(action);

    #endregion

    #region Invoke

    public static void OnItemCollect(Item item) =>
        _onItemCollect.Invoke(item);

    #endregion
}