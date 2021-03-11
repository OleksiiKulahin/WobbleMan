using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingPath : MonoBehaviour
{
    public enum movementType
    {
        Moving,
        Lerping
    }
    public movementType type = movementType.Moving;
    public MovementPath path;
    public float speed = 1f;
    public float maxDistance = .1f;

    private IEnumerator<Transform> pointInPath;
    private Rigidbody rigidbody;
    private GameManager gm;

    public void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        rigidbody = GetComponent<Rigidbody>();
        if (path==null)
        {
            Debug.Log("Use the path");
            return;
        }
        pointInPath = path.getNextPathPoint();
        pointInPath.MoveNext();
        if (pointInPath.Current==null)
        {
            Debug.Log("Points needed");
            return;
        }
        rigidbody.position = pointInPath.Current.position;
    }

    public void Update()
    {
        if (gm.getPause())
        {
            return;
        }
        if (pointInPath==null || pointInPath.Current==null)
        {
            return;
        }

        switch (type)
        {
            case movementType.Moving:
                rigidbody.position = Vector3.MoveTowards(transform.position, pointInPath.Current.position, Time.deltaTime * speed);
                rigidbody.MoveRotation(Quaternion.LookRotation(Vector3.RotateTowards(
                        transform.forward, pointInPath.Current.position - gameObject.transform.position,
                        2 * speed * Time.deltaTime, 0.0f)));
                break;
            case movementType.Lerping:
                transform.position = Vector3.Lerp(transform.position, pointInPath.Current.position, Time.deltaTime * speed);
                rigidbody.MoveRotation(Quaternion.LookRotation(Vector3.RotateTowards(
                        transform.forward, pointInPath.Current.position - gameObject.transform.position,
                        2 * speed * Time.deltaTime, 0.0f))); 
                break;
            default:
                break;
        }
        var distanceSquare = (transform.position - pointInPath.Current.position).sqrMagnitude;
        if (distanceSquare<maxDistance*maxDistance)
        {
            pointInPath.MoveNext();
        }
    }
}
