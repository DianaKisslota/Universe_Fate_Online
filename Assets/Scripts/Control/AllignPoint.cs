using UnityEngine;

public static class AllignPoint
{
    //public Vector3 ToIn(Vector3 sourcePoint)
    //{
    //    var result = sourcePoint;
    //    if (agent.transform.position.x < result.x)
    //        result.x = Mathf.FloorToInt(result.x);
    //    else
    //        result.x = Mathf.CeilToInt(result.x);
    //    if (agent.transform.position.z < result.z)
    //        result.z = Mathf.FloorToInt(result.z);
    //    else
    //        result.z = Mathf.CeilToInt(result.z);
    //    return result;
    //}

    public static Vector3 ToMid(Vector3 sourcePoint)
    {
        var result = sourcePoint;
        result.x = Mathf.Round(result.x);
        result.z = Mathf.Round(result.z);
        return result;
    }

}
