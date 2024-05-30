using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PointerType
{
    Nav = 0,
    Target = 1
}

public class PointerController : MonoBehaviour
{
    [SerializeField] private GameObject _nav;
    [SerializeField] private GameObject _target;

    public void SetPointerMaterial(Material material)
    {
        foreach (var mesh in _nav.GetComponentsInChildren<MeshRenderer>())
        {
            mesh.material = material;
        }
    }

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }

    public bool activeSelf
    {
        get
        {
            return gameObject.activeSelf;
        }
    }

    public Vector3 position
    {
        get
        {
            return gameObject.transform.position;

        }
        set
        {
            gameObject.transform.position = value;
        }
    }

    public void SetPointerType(PointerType type)
    {
        switch (type)
        {
            case PointerType.Nav:
                _target.SetActive(false);
                _nav.SetActive(true);
                break;
            case PointerType.Target:
                _nav.SetActive(false);
                _target.SetActive(true);
                break;        
        }        
    }



}
