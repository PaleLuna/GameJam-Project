using System;

public class Woods : Item
{
    public override void Collect(Action action = null)
    {
        GameplayEventBus.OnItemCollect(this);
        gameObject.SetActive(false);
    }
}