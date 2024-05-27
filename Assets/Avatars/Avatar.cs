using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Animations
{
    Idle,
    Move,
    MeleeAttack,
    DistanceAttack,
    Diyng
}
public class Avatar : MonoBehaviour
{
    public BaseEntity Entity { get; set; }
    //public GameObject Model {  get; set; }
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
}
