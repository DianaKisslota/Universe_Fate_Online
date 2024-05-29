using UnityEngine;
using UnityEngine.AI;

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
    private Animator _animator;
    private NavMeshAgent _agent;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
    }
}
