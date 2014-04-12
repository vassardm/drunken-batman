using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public string pathName;

    private Vector3[] path;
    private int currentPoint;

    void Start()
    {
        path = GetRelativePath(pathName, transform.position);
        currentPoint = 0;
    }
	
	// Update is called once per frame
	void Update()
    {
        int index = currentPoint % path.Length;
        currentPoint++;
        iTween.MoveUpdate(gameObject, path[index], 2);
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
