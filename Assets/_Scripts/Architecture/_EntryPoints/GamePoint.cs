using System.Collections;
using _Scripts.Gameplay.Input_System;
using UnityEngine;

public class GamePoint : MonoBehaviour
{
    private IEnumerator Start()
    {
        ServiceLocator serviceLocator = ServiceLocator.Instance;

        serviceLocator.Registarion(new InputService(new PCInput()));

        yield return null;
    }
}