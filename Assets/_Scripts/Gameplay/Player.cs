using System;
using UnityEngine;

public class Player : MonoBehaviour, IFixedUpdatable, IStartable
{
   [SerializeField] private Rigidbody _rigidbody;
   [SerializeField] private PlayerConfig _playerConfig;
   [SerializeField] private Transform _modelTransfrom;

   private IControllable _controllable;
   private PlayerLookForward _playerLookForward;

   public void OnStart()
   {
      _controllable = new RBControllable(_rigidbody);
      _playerLookForward = new PlayerLookForward(_modelTransfrom);
      
      GameController gameController = ServiceLocator.Instance.Get<GameController>();
      gameController.updatablesHolder.Registration(this);
   }

   public void FixedFrameRun()
   {
      _controllable.Move(_playerConfig.Speed);
   }

   
}
