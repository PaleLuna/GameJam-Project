using System;
using UnityEngine;

public abstract class Item : MonoBehaviour, ICollectable
{
    [SerializeField] private ItemDescription _description;

    public ItemDescription description => _description;
    
    public abstract void Collect(Action action = null);
}
