using System;

public class Woods : Item
{
    public override void Collect(Action action = null)
    {
        print(_description.itemName);
        
        GameplayEventBus.OnItemCollect(this);
        gameObject.SetActive(false);
    }
}