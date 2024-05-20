using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Navigation : MonoBehaviour
{
    public Button North, South, West, East, NorthWest, NorthEast, SouthWest, SouthEast;

    public float ZStep = 1f;
    public float XStep = 2f;

    public float Speed = 10f;

    private Dictionary<Button, Vector3> _directionsMap;
    private Vector3 _targetPosition;

    public event Action<string> ArriveToSector;

    void Start()
    {
        _directionsMap = new Dictionary<Button, Vector3>();

        _directionsMap.Add(North, new Vector3(0, 0, ZStep));
        _directionsMap.Add(South, new Vector3(0, 0, -ZStep));
        _directionsMap.Add(West, new Vector3(-XStep, 0, 0));
        _directionsMap.Add(East, new Vector3(XStep, 0, 0));

        _directionsMap.Add(NorthWest, _directionsMap[North] + _directionsMap[West]);
        _directionsMap.Add(NorthEast, _directionsMap[North] + _directionsMap[East]);
        _directionsMap.Add(SouthWest, _directionsMap[South] + _directionsMap[West]);
        _directionsMap.Add(SouthEast, _directionsMap[South] + _directionsMap[East]);

        foreach (var item in _directionsMap)
            item.Key.onClick.AddListener(() =>
                {
                    _targetPosition += item.Value;
                    ArriveToSector?.Invoke(item.Key.name);
                }
                );

        _targetPosition = transform.position;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _targetPosition, Speed * Time.deltaTime);
    }
}