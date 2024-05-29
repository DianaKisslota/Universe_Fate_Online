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
    public GameObject nav;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPointerMaterial(Material material)
    {
        foreach (var mesh in nav.GetComponentsInChildren<MeshRenderer>())
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
                target.SetActive(false);
                nav.SetActive(true);
                break;
            case PointerType.Target:
                nav.SetActive(false);
                target.SetActive(true);
                break;        
        }        
    }



}
