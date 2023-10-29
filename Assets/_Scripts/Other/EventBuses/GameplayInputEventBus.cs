using UnityEngine;
using UnityEngine.Events;

public static class GameplayInputEventBus
{
    private static UnityEvent<Vector3> onGetDirection = new UnityEvent<Vector3>();
    private static UnityEvent onInteract = new UnityEvent();

    #region SubscribeMethods

    public static void SubscribeOnGetDirection(UnityAction<Vector3> action) =>
        onGetDirection.AddListener(action);
    public static void SubscribeOnInteract(UnityAction action) =>
        onInteract.AddListener(action);

    #endregion

    #region Unsubscribe

    public static void UnsubscribeOnGetDirection(UnityAction<Vector3> action) =>
        onGetDirection.RemoveListener(action);
    public static void UnsubscribeOnInteract(UnityAction action) =>
        onInteract.RemoveListener(action);

    #endregion

    #region Invoke

    public static void OnGetDirection(Vector3 direction) =>
        onGetDirection.Invoke(direction);
    public static void OnInteract() =>
        onInteract.Invoke();

    #endregion
}
