using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float _speedMove;
    private Vector3 _moveVector;
    public JoystickController joystickController;
    public GameManager gameManager;
    public TrailRenderer trailRenderer;
    public Rigidbody _rb;
    public Vector3 _groundLocation;

    void Start()
    {
        startSettings();
    }

    void FixedUpdate()
    {
        if (!gameManager.getPause())
        {
            if (SystemInfo.operatingSystemFamily == OperatingSystemFamily.Windows
                || SystemInfo.operatingSystemFamily == OperatingSystemFamily.MacOSX)
            {
                CharacterMove();
            }
        }
    }

    private void CharacterMove()
    {
        _moveVector = Vector3.zero;

        _moveVector.x = joystickController.getHorizontal()*_speedMove;
        _moveVector.z = joystickController.getVertical()*_speedMove;

        if (Vector3.Angle(Vector3.forward,_moveVector)>1f||Vector3.Angle(Vector3.forward,_moveVector)==0)
        {
            _rb.MoveRotation(Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, _moveVector, _speedMove, 0.0f)));
        }
        _rb.MovePosition(transform.position+Time.deltaTime*_moveVector);
    }

    public void startSettings()
    {
        _rb = GetComponent<Rigidbody>();
        joystickController.transform.position = new Vector3(0,0,0);
        trailRenderer.emitting = false;
        transform.position = new Vector3(0, 1.5f, 0);
        transform.rotation = Quaternion.Euler(0, 0, 0);
        trailRenderer.Clear();
        trailRenderer.emitting = true ;
    }
}
