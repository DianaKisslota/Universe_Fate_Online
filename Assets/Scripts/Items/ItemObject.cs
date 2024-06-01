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

    public event Action<ItemObject> OnItemClick;

    private void Start()
    {
        _light = GetComponent<Light>();
        _rigidBody = GetComponent<Rigidbody>();
        _light.enabled = false;
    }

    public void Take()
    {
        _isFree = false;
        OnItemClick = null;
        LightOff();
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
        //_light.enabled = true;
    }

    private void OnMouseExit()
    {
       // _light.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<CharacterAvatar>(out var character) && _isFree)
        {
            _light.enabled = true;
            OnItemClick += character.ClickToItem;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<CharacterAvatar>(out var character) && _isFree)
        {
            _light.enabled = false;
            OnItemClick -= character.ClickToItem;
        }
    }

    private void OnMouseDown()
    {
        OnItemClick?.Invoke(this);
    }

}
