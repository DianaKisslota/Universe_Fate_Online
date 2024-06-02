using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAvatar : EntityAvatar
{
    [SerializeField] Transform _weaponPoint;
    [SerializeField] Transform _weaponBackPoint;
    private List<Quant> _quants = new List<Quant>();

    public event Action StartApplainQuants;
    public event Action EndApplainQuants;

    private bool _quantsApplaying = false;

    public void ClickToItem(ItemObject itemObject)
    {
        if (Vector3.Distance(transform.position, itemObject.transform.position) < 1.2f)
        {
            if (itemObject.Item is Weapon)
            {
                if ((itemObject.Item as Weapon).WeaponType == WeaponType.Rifle || (itemObject.Item as Weapon).WeaponType == WeaponType.AssaultRifle)
                    itemObject.gameObject.transform.parent = _weaponBackPoint;
                else
                    itemObject.gameObject.transform.parent = _weaponPoint;
                itemObject.gameObject.transform.localPosition = Vector3.zero;
                itemObject.gameObject.transform.localRotation = Quaternion.identity;
            }
            itemObject.Take();
        }
    }

    public void AddQuant(EntityAction action, object _object)
    {
        _quants.Add(new Quant(action, _object));
    }

    public void AddMoveQuant(Vector3 point)
    {
        AddQuant(EntityAction.Move, point);
    }

    public void RemoveLastQuant()
    {
        _quants.RemoveAt(_quants.Count - 1);
    }

    public void RemoveAllQuants()
    {
        _quants.Clear();
    }

    private void StartCurrentQuant()
    {
        if (_quants.Count == 0)
            return;
        switch (_quants[0].Action)
        {
            case EntityAction.Move:
                MoveTo((_quants[0].Object as Vector3?).Value);
                break;
            default:
                Debug.LogError("Неизвестный тип действия");
                break;
        }
    }

    public void SetToPosition(Vector3 position)
    {
        _agent.destination = position;
        _agent.enabled = false;
        transform.position = position;
        _walkingTo = null;
        _agent.enabled = true;
    }

    public void ApplyQuants()
    {
        if (_quants.Count == 0)
            return;
        StartApplainQuants?.Invoke();
        _quantsApplaying = true;
        StartCurrentQuant();
    }

    protected override void CheckWalking()
    {
        base.CheckWalking();
    }

    protected override void AdditionChecks()
    {  
        base.AdditionChecks();
        
        if ( _quantsApplaying)        
        {
            var quantEnded = false;
            switch (_quants[0].Action)
            {
                case EntityAction.Move:
                    {
                        quantEnded = _walkingTo == null;
                    }
                    break;
                default:
                    Debug.LogError("Неизвестный тип действия");
                    break;
            }
            if (quantEnded)
            {
                _quants.RemoveAt(0);
                if (_quants.Count > 0)
                    StartCurrentQuant();
                else
                {
                    _quantsApplaying = false;
                    EndApplainQuants?.Invoke();
                }
            }
        }
    }

}
