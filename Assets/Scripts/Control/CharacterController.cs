using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class CharacterController : AvatarController
{
    [SerializeField] private Material AccessMoveMaterial;
    [SerializeField] private Material RestrictMoveMaterial;

    [SerializeField] private PointerController _pointer;
 //   [SerializeField] protected LineRenderer _pathDrawer;

    private Vector3 _originPoint;
    private Vector3 _originAngle;

    private Vector3 _lastPoint;
    private Vector3 _lastAngle;
    private CharacterAvatar _playerAvatar => _avatar as CharacterAvatar;

    private List<GameObject> _navPoints = new List<GameObject>();


    private bool _canMove;

    private bool _avatarMoving;
    private bool _avatarApplyingQants;
    private bool AvatarBusy => _avatarMoving || _avatarApplyingQants;

    private void Start()
    {
        _playerAvatar.StartMoving += () => _avatarMoving = true;
        _playerAvatar.EndMoving += () => _avatarMoving = false;
        _playerAvatar.StartApplainQuants += () => _avatarApplyingQants = true;
        _playerAvatar.EndApplainQuants += () =>
        {
            _originPoint = _playerAvatar.transform.position;
            _originAngle = _playerAvatar.transform.eulerAngles;
            _avatarApplyingQants = false;
        };

        _originPoint = _playerAvatar.transform.position;
        _originAngle = _playerAvatar.transform.eulerAngles;
        _lastPoint = _playerAvatar.transform.position;
        _lastAngle = _playerAvatar.transform.eulerAngles;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _canMove && !AvatarBusy)
        {
            var navPoint = Instantiate(Global.NavPointPrefab);
            navPoint.transform.position = _pointer.position;
            _navPoints.Add(navPoint);

            _lastPoint = _playerAvatar.transform.position;
            _lastAngle = _playerAvatar.transform.eulerAngles;

            var path = new NavMeshPath();

            if (_playerAvatar.CalculateCompletePath(_pointer.position, path))
            {
                //DrawPath(path);
                _playerAvatar.MoveTo(_pointer.position);
                _playerAvatar.AddMoveQuant(_pointer.position);
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            ApplyQuants();
        }
    }

    private void OnMouseOver()
    {
        if (_pointer != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            var pointerPosition = hit.point;
            var movePosition = AllignPoint.ToMid(pointerPosition);

            _canMove = PlayerCanReach(movePosition);
            _pointer.SetActive(_canMove && !AvatarBusy);
            if (_pointer.activeSelf && _pointer.position != movePosition)
            {
                _pointer.position = movePosition;

                //if (playerController.PlayerCanReach(_pointer.transform.position))
                _pointer.SetPointerMaterial(AccessMoveMaterial);
                //else
                //    _pointer.SetPointerMaterial(RestrictMoveMaterial);
            }
        }
    }

    void OnMouseExit()
    {
        _pointer.SetActive(false);
    }

    //private void DrawPath(NavMeshPath path)
    //{
    //    var startPosition = _pathDrawer.positionCount;
    //    _pathDrawer.positionCount += path.corners.Length;
    //    for (var i = startPosition; i < _pathDrawer.positionCount; i++)
    //    {
    //        _pathDrawer.SetPosition(i, path.corners[i - startPosition]);
    //    }
    //}

    private bool PlayerCanReach(Vector3 point)
    {
        return _playerAvatar.CalculateCompletePath(point, new NavMeshPath());
    }

    private void ApplyQuants()
    {
        foreach (var point in _navPoints)
        {
            Destroy(point);
        }
        _navPoints.Clear();
        _playerAvatar.transform.position = _originPoint;
        _playerAvatar.transform.eulerAngles = _originAngle;

        _playerAvatar.ApplyQuants();
    }

    private void ClearLastNavPoint()
    {
        if (_navPoints.Count == 0)
            return;
        Destroy(_navPoints[_navPoints.Count - 1]);
        _navPoints.RemoveAt(_navPoints.Count - 1);
        _playerAvatar.RemoveLastQuant();
        if (_navPoints.Count == 0)
        {
            _playerAvatar.SetToPosition(_originPoint);
            _playerAvatar.transform.eulerAngles -= _originAngle;
        }
        else
        {
            _playerAvatar.SetToPosition(_navPoints[_navPoints.Count - 1].transform.position);
            //_playerAvatar.transform.eulerAngles = _lastAngle;
            //_lastPoint = _navPoints[_navPoints.Count - 1].transform.position;
        }

    }

    private void ClearAllNavPoints()
    {
        foreach (var point in _navPoints)
        {
            Destroy(point);
        }
        _navPoints.Clear();

        _playerAvatar.RemoveAllQuants();
        _playerAvatar.SetToPosition(_originPoint);
        _playerAvatar.transform.eulerAngles -= _originAngle;
    }

    public void ButtonApplyQuantsClick()
    {
        ApplyQuants();
    }

    public void ButtonClearLastClick()
    {
        ClearLastNavPoint();
    }

    public void ButtonClearAllNavPoints()
    {
        ClearAllNavPoints();
    }

}
