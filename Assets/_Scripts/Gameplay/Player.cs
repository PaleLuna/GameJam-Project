using System;
using UnityEngine;

public class Player : MonoBehaviour, IFixedUpdatable, IStartable
{
   [SerializeField] private Rigidbody _rigidbody;
   [SerializeField] private PlayerConfig _playerConfig;

   private IControllable _controllable;

   public void OnStart()
   {
      _controllable = new RBControllable(_rigidbody);
      
      GameController gameController = ServiceLocator.Instance.Get<GameController>();
      gameController.updatablesHolder.Registration(this);
   }

   public void FixedFrameRun()
   {
      _controllable.Move(_playerConfig.Speed);
   }

   
}
