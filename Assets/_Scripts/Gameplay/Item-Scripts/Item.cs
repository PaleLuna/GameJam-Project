using System;
using UnityEngine;

public abstract class Item : MonoBehaviour, ICollectable
{
    [Header("Description")]
    [SerializeField] protected ItemDescription _description;

    public ItemDescription description => _description;
    
    public abstract void Collect(Action action = null);
}
