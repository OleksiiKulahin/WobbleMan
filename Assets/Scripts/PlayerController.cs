using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float _speedMove;
    private Vector3 _moveVector;
    private CharacterController characterController;
    public JoystickController joystickController;
    public GameManager gameManager;
    public TrailRenderer trailRenderer;

    void Start()
    {
        startSettings();
    }

    void Update()
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

        _moveVector.x = joystickController.getHorizontal() * _speedMove;
        _moveVector.z = joystickController.getVertical() * _speedMove;

        if (Vector3.Angle(Vector3.forward,_moveVector)>1f||Vector3.Angle(Vector3.forward,_moveVector)==0)
        {
            Vector3 direct = Vector3.RotateTowards(transform.forward, _moveVector, _speedMove, 0.0f);
            transform.rotation = Quaternion.LookRotation(direct);
        }

        characterController.Move(_moveVector * Time.deltaTime);
    }

    public void startSettings()
    {
        //_speedMove = 5;
        characterController = GetComponent<CharacterController>();
        joystickController.transform.position = new Vector3(0,0,0);
        trailRenderer.emitting = false;
        transform.position = new Vector3(0, 1.5f, 0);
        trailRenderer.Clear();
        trailRenderer.emitting = true ;
    }
}
