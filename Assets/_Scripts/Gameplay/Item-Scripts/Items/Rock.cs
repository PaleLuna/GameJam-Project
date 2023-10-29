using System;

public class Rock : Item
{
    public override void Collect(Action action = null)
    {
        ServiceLocator.Instance.Get<GameResources>().AddItem(this);
        action?.Invoke();
    }
}