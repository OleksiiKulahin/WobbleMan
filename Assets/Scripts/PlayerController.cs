using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speedMove;
    private Vector3 _moveVector;
    public JoystickController joystickController;
    public GameManager gameManager;
    public TrailRenderer trailRenderer;
    public Rigidbody rb;

    void Start()
    {
        startSettings();
    }

    void FixedUpdate()
    {
        if (!gameManager.getPause())
        {
            CharacterMove();
        }
    }

    private void CharacterMove()
    {
        _moveVector = Vector3.zero;

        _moveVector.x = joystickController.getHorizontal()*speedMove;
        _moveVector.z = joystickController.getVertical()*speedMove;

        if (Vector3.Angle(Vector3.forward,_moveVector)>1f||Vector3.Angle(Vector3.forward,_moveVector)==0)
        {
            rb.MoveRotation(Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, _moveVector, speedMove, 0.0f)));
        }
        rb.MovePosition(transform.position+Time.deltaTime*_moveVector);
    }

    public void startSettings()
    {
        speedMove = 5;
        rb = GetComponent<Rigidbody>();
        joystickController.transform.position = new Vector3(0,0,0);
        trailRenderer.emitting = false;
        rb.position=GameObject.Find("LevelManager").GetComponent<LevelManager>().levelList[0]
            .GetComponent<Level>().playerSpawn.transform.position;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        trailRenderer.Clear();
        trailRenderer.emitting = true ;
    }
}
