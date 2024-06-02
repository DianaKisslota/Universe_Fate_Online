﻿using UnityEngine;

public enum EntityAction
{
    Move,
    DistantAttack,
    PickObject
}
public class Quant
{
    public EntityAction Action { get; private set; }
    public object Object {  get; private set; }

    public Vector3? LastPosition {  get; private set; }
    public Quaternion LastRotation { get; private set; }

    public Quant(EntityAction _action, object _object, Vector3? _lastPosition, Quaternion lastRotation)
    {
        Action = _action;
        Object = _object;
        LastPosition = _lastPosition;
        LastRotation = lastRotation;
    }

    public Vector3? GetPosition()
    {
        switch (Action) 
        { 
            case EntityAction.Move:
                {
                    return Object as Vector3?;
                }
            default: return null;
        }
    }
}

