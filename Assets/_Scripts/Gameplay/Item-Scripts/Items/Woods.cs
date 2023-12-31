﻿using System;

public class Woods : Item
{
    public override void Collect(Action action = null)
    {
        ServiceLocator.Instance.Get<GameResources>().AddItem(this);
        action?.Invoke();
    }
}