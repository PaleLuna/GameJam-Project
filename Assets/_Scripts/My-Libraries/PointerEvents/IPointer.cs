using UnityEngine;
using UnityEngine.Events;

namespace PaleLuna.PointEvents
{
    public interface IPointer
    {

        public void onPointCliclSubscribe(UnityAction<Vector3> action);
        public void onPointClickUnsubscribe(UnityAction<Vector3> action);

        public void FollowThePointer(GameObject obj);

        public void CreateMassageOnClick(string msg);
    }
}