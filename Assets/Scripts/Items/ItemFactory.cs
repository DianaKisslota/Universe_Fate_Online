using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public static class ItemFactory
{
    public static ItemObject CreateItem(Type itemType, GameObject parent = null)
    {
        var modelPrefab = Global.GetPrefabForItem(itemType);
        var model = GameObject.Instantiate<GameObject>(modelPrefab);
        var itemObject = model.AddComponent<ItemObject>();
        model.AddComponent<Rigidbody>();
        var item = Activator.CreateInstance(itemType) as Item;
        itemObject.Item = item;

        return itemObject;
    }
}

