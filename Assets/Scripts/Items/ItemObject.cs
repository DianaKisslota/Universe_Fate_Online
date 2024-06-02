using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    private Rigidbody _rigidBody;
    public Item Item {  get; set; }
    public Light _light {  get; set; }

    private bool _isFree  = true;


    private void Start()
    {
        _light = GetComponent<Light>();
        _rigidBody = GetComponent<Rigidbody>();
        _light.enabled = false;
    }

    public void Drop()
    {
        _isFree = true;
        SetKinematic(false);
    }

    public void Take()
    {
        _isFree = false;
        LightOff();
        SetKinematic(true);
    }

    public void SetKinematic(bool kinematic)
    {
        _rigidBody.isKinematic = kinematic;
    }

    public void LightOff()
    {
        _light.enabled = false;
    }
    private void OnMouseOver()
    {
        if (_isFree) 
            _light.enabled = true;
    }

    private void OnMouseExit()
    {
        if (_isFree)
            _light.enabled = false;
    }
}
