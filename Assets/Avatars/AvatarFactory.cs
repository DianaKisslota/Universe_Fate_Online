﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public static class AvatarFactory
{
    public static Avatar CreateMob(Type entityType, GameObject parent = null)
    {
        var modelPrefab = Global.GetPrefabForEntity(entityType);
        var model = GameObject.Instantiate<GameObject>(modelPrefab);
        var avatar = model.AddComponent<Avatar>();
        avatar.Entity = Activator.CreateInstance(entityType) as BaseEntity;

        return avatar;
    }
}

