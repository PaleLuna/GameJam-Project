using System;
using UnityEngine;
using UnityEngine.Serialization;

public class AnimationController : MonoBehaviour, IStartable
{
    [SerializeField] private Animator _animator;

    private readonly int _runAnimHash = Animator.StringToHash("Pers_Run");
    private readonly int _idleAnimHash = Animator.StringToHash("Idle");

    private readonly int _speedValueHash = Animator.StringToHash("Speed");

    private void OnValidate()
    {
        _animator ??= GetComponent<Animator>();
    }


    public void OnStart()
    {
        GameplayInputEventBus.SubscribeOnGetDirection(SetSpeed);
    }

    private void SetSpeed(Vector3 direction)
    {
        float speed = direction.magnitude;
        
        _animator.SetFloat(_speedValueHash, speed);
    }
}
