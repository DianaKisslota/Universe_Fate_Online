using System;
using UnityEngine;

public static class ItemFactory
{
    public static ItemObject CreateItem(Type itemType, GameObject parent = null)
    {
        var modelPrefab = Global.GetPrefabForItem(itemType);
        var model = GameObject.Instantiate<GameObject>(modelPrefab);
        var itemObject = model.AddComponent<ItemObject>();
        model.AddComponent<Rigidbody>();
        //var light = model.AddComponent<Light>();
        //light.intensity = 10;
        //light.range = 2;
        //light.color = new Color(19, 87, 3);
        var item = Activator.CreateInstance(itemType) as Item;
        itemObject.Item = item;

        return itemObject;
    }
}

