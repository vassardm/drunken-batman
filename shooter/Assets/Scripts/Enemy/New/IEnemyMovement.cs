using UnityEngine;
using System.Collections;

public abstract class IEnemyMovement
{
    float Speed { get; set; }

    Vector3[] GetRelativePath(string pathName, Vector3 relativePoint)
    {
        Vector3[] path = iTweenPath.GetPath(pathName);
        Vector3[] result = new Vector3[path.Length];

        for (int i = 0; i < path.Length; i++)
        {
            result[i] = relativePoint + path[i];
        }

        return result;
    }
}
