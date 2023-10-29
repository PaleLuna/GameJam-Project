using UnityEngine;
using UnityEngine.Events;

public static class GameplayInputEventBus
{
    private static UnityEvent<Vector3> onGetDirection = new UnityEvent<Vector3>();
    private static UnityEvent onInrteract = new UnityEvent();

    #region SubscribeMethods

    public static void SubscribeOnGetDirection(UnityAction<Vector3> action) =>
        onGetDirection.AddListener(action);
    public static void SubscribeOnInrteract(UnityAction action) =>
        onInrteract.AddListener(action);

    #endregion

    #region Unsubscribe

    public static void UnsubscribeOnGetDirection(UnityAction<Vector3> action) =>
        onGetDirection.RemoveListener(action);
    public static void UnsubscribeOnInrteract(UnityAction action) =>
        onInrteract.RemoveListener(action);

    #endregion

    #region Invoke

    public static void OnGetDirection(Vector3 direction) =>
        onGetDirection.Invoke(direction);
    public static void OnInrteract() =>
        onInrteract.Invoke();

    #endregion
}
