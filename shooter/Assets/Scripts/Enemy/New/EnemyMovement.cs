using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public string pathName;

    void Start()
    {
		iTween.MoveTo(gameObject, iTween.Hash ("path", GetRelativePath (this.pathName, this.transform.position), "speed", this.speed, "looptype", iTween.LoopType.loop));
    }

    private Vector3[] GetRelativePath(string pathName, Vector3 relativePoint)
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
