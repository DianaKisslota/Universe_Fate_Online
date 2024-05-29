using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationController : MonoBehaviour
{
    [SerializeField] private PointerController _pointer;
    [SerializeField] private EntityAvatar _playerAvatar;

    [SerializeField] private Material AccessMoveMaterial;
    [SerializeField] private Material RestrictMoveMaterial;

    private void OnMouseOver()
    {
        if (_pointer != null) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            var pointerPosition = hit.point;
            var movePosition = AllignPoint.ToMid(pointerPosition);
            _pointer.SetActive(true);
            //movePointer.SetActive(playerController.PlayerCanMove && !UIInact && !UIBlockedByScenario);
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

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _playerAvatar.MoveTo(_pointer.position);
        }
    }
}
