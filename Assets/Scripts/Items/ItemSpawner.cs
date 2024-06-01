using System;

public class ItemSpawner
{
    public Type ItemType { get; private set; }

    public ItemSpawner(Type itemType)
    {
        ItemType = itemType;
    }
}

