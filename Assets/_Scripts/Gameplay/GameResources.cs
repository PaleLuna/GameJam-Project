public class GameResources
{
    private TypeCountHolder<Item> _resources = new TypeCountHolder<Item>();

    public void AddItem(Item item)
    {
        _resources.Registration(item);
        item.gameObject.SetActive(false);
        GameplayEventBus.OnItemCollect(item);
    }

    public int CheckCount<T>() where T : Item => 
        _resources.GetCountOfType<T>();

    public void Take<T>(int amount) where T : Item
    {
        _resources.RemoveItems<T>(amount);
        
        GameplayEventBus.OnItemRemove(typeof(T));
    }

    public bool TryTake<T>(int amount) where T : Item
    {
        int count = CheckCount<T>();

        if (count < amount) return false;

        Take<T>(amount);
        
        return true;
    }
}
