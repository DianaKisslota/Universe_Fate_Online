using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Global 
{
    public static string CurrentMapName = null;
    public static string CurrentSectorID = null;

    private static Dictionary<Type, GameObject> EntityPrefabs = new Dictionary<Type, GameObject>();
    public static GameObject GetPrefabForEntity(Type entityType)
    {
        EntityPrefabs.TryGetValue(entityType, out GameObject obj);
        return obj;
    }

    static Global()
    {
        EntityPrefabs.Add(typeof(FeralDog), Resources.Load<GameObject>("EntityModels/Wolf_Animated/Prefabs/Wolf"));
        EntityPrefabs.Add(typeof(Reptiloid), Resources.Load<GameObject>("EntityModels/Rake/Perfabs/Rake_A"));    }
}
