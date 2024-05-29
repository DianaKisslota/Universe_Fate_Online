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
public class EntityAvatar : MonoBehaviour
{
    public BaseEntity Entity { get; set; }
    protected Animator _animator;
    protected NavMeshAgent _agent;

    protected Vector3? _walkingTo;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
    }

    public void MoveTo(Vector3 movePoint)
    {
        if (InPoint(movePoint))
            return;
        _walkingTo = movePoint;
        _animator.SetTrigger("Walk");
        _agent.destination = movePoint;
    }

    private void Update()
    {
        if (_walkingTo != null && InPoint(_walkingTo.Value))
        {
            _animator.SetTrigger("Idle");
            _walkingTo = null;
        }
    }

    private bool InPoint(Vector3 point)
    {
        return Mathf.Round(gameObject.transform.position.x) == point.x && Mathf.Round(gameObject.transform.position.z) == point.z;
    }

}
