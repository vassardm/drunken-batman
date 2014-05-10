using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public string pathName;
    public bool loop;
    THorseSystemMechanics th;

    void Start()
    {
        th = Camera.main.GetComponent<THorseSystemMechanics>();

        Hashtable hash = iTween.Hash("path", GetRelativePath(this.pathName, this.transform.position),
            "speed", (this.speed + th.GetModifier(0)));
        if (loop) { hash.Add("looptype", iTween.LoopType.loop); }
		iTween.MoveTo(gameObject, hash);
    }

    // Starting point must be (0,0,0)
    private Vector3[] GetRelativePath(string pathName, Vector3 relativePoint)
    {
        Vector3[] path = iTweenPath.GetPath(pathName);
        Vector3[] convertedPath = MakeRelativePath(path);
        Vector3[] result = new Vector3[convertedPath.Length];
        for (int i = 0; i < convertedPath.Length; i++)
        {
            result[i] = relativePoint + convertedPath[i];
        }

        return result;
    }

    private Vector3[] MakeRelativePath(Vector3[] path)
    {
        Vector3[] convertedPath = new Vector3[path.Length];
        Vector3 startingPoint = path[0];
        float startX = startingPoint.x;
        float startY = startingPoint.y;
        float startZ = startingPoint.z;
        for (int i = 0; i < path.Length; i++) 
        {
            Vector3 point = path[i];
            Vector3 newPoint = new Vector3(point.x, point.y, point.z);
            newPoint.x -= startX;
            newPoint.y -= startY;
            newPoint.z -= startZ;
            convertedPath[i] = newPoint;
        }
        return convertedPath;
    }

}
