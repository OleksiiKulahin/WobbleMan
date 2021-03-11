using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPath : MonoBehaviour
{
    public enum PathTypes
    {
        linear,
        loop
    }
    public PathTypes pathType;
    public int movementDirection = 1;
    public int movingTo = 0;
    public Transform[] pathElements;

    public void OnDrawGizmos()
    {
        if (pathElements==null||pathElements.Length<2)
        {
            return;
        }
        for (int i = 1; i < pathElements.Length; i++)
        {
            Gizmos.DrawLine(pathElements[i - 1].position, pathElements[i].position);
        }
        if (pathType == PathTypes.loop)
        {
            Gizmos.DrawLine(pathElements[0].position, pathElements[pathElements.Length - 1].position);
        }
    }

    public IEnumerator<Transform> getNextPathPoint()
    {
        if (pathElements==null || pathElements.Length<1)
        {
            yield break;
        }
        while (true)
        {
            yield return pathElements[movingTo];
            if (pathElements.Length==1)
            {
                continue;
            }
            if (pathType==PathTypes.linear)
            {
                if (movingTo<=0)
                {
                    movementDirection = 1;
                }
                else if (movingTo>=pathElements.Length-1)
                {
                    movementDirection = -1;
                }
            }
            movingTo = movingTo + movementDirection;
            if (pathType==PathTypes.loop)
            {
                if (movingTo>=pathElements.Length)
                {
                    movingTo = 0;
                }
                if (movingTo<0)
                {
                    movingTo = pathElements.Length - 1;
                }
            }
        }
    }
}
