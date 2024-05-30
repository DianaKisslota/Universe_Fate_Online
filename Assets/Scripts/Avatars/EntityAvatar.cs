using System;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.EventSystems.EventTrigger;

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

    public bool IsMoving {  get; set; }

    public event Action StartMoving;
    public event Action EndMoving;

    private float _timeBeforeAgentEnabled = 0;

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
        StartMoving!.Invoke();
    }

    protected virtual void CheckWalking()
    {
        if (_walkingTo != null && InPoint(_walkingTo.Value))
        {
            _animator.SetTrigger("Idle"); 
            _walkingTo = null;
            StopAgent(0.5f);
            EndMoving?.Invoke();
        }
    }

    protected void StopAgent(float sec)
    {
        _timeBeforeAgentEnabled = sec;
        _agent.isStopped = true;
    }

    protected virtual void AdditionChecks()
    {

    }

    private void Update()
    {
        if (_timeBeforeAgentEnabled > 0)
        {
            _timeBeforeAgentEnabled -= Time.deltaTime;
        }

        _agent.isStopped = _timeBeforeAgentEnabled > 0;        
        CheckWalking();
        AdditionChecks();
    }

    protected bool InPoint(Vector3 point)
    {
        return Mathf.Round(gameObject.transform.position.x) == point.x && Mathf.Round(gameObject.transform.position.z) == point.z;
    }

    public bool CalculateCompletePath(Vector3 targetPoint, NavMeshPath path)
    {
        var result = _agent.enabled && _agent.CalculatePath(targetPoint, path);
        if (!result)
            return false;
        var endPoint = path.corners[path.corners.Length - 1];
        return Mathf.Abs(endPoint.x - targetPoint.x) < 0.001 && Mathf.Abs(endPoint.z - targetPoint.z) < 0.001;
    }

    public float PathLength(NavMeshPath path)
    {
        float result = 0;
        for (int i = 1; i < path.corners.Length; i++)
        {
            result += Vector3.Distance(path.corners[i - 1], path.corners[i]);
        }
        return result;
    }


    //public bool PathReachable(NavMeshPath path)
    //{
    //    return PathLength(path) <= entity.MaxDistance();
    //}



}
