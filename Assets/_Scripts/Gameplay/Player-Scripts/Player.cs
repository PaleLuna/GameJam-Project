using System;
using UnityEngine;

public class Player : MonoBehaviour, IFixedUpdatable, IStartable
{
   [SerializeField] private Rigidbody _rigidbody;
   [SerializeField] private PlayerConfig _playerConfig;
   [SerializeField] private Transform _modelTransfrom;

   [SerializeField] private ColliderDetector _colliderDetector;

   public ICollisionDetecter CollisionDetecter => _colliderDetector;

   private IControllable _controllable;
   private PlayerLookForward _playerLookForward;

   public void OnStart()
   {
      _controllable = new RBControllable(_rigidbody, this);
      _playerLookForward = new PlayerLookForward(_modelTransfrom);
      
      GameController gameController = ServiceLocator.Instance.Get<GameController>();
      gameController.updatablesHolder.Registration(this);
   }

   public void FixedFrameRun()
   {
      _controllable.Move(_playerConfig.Speed);
   }
}
