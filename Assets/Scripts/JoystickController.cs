using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image joystickBG;
    private Image joystick;
    private Vector2 inputVector;
    public GameManager gm;

    public void Start()
    {
        joystickBG = GetComponent<Image>();
        joystick = transform.GetChild(0).GetComponent<Image>();
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        if (gm.getPause())gm.changePause();
        moveJoystick();
        OnDrag(eventData);
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        joystick.rectTransform.anchoredPosition = new Vector2(150,150);
        joystickBG.rectTransform.position = Vector2.zero;
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            joystickBG.rectTransform, eventData.position, eventData.pressEventCamera, out pos))
        {
            pos.x = (pos.x / (joystickBG.rectTransform.sizeDelta.x/8));
            pos.y = (pos.y / (joystickBG.rectTransform.sizeDelta.y/8));

            inputVector = new Vector2(pos.x * 2, pos.y * 2);
            if (inputVector.magnitude > 1f)
            {
                joystickBG.rectTransform.position = joystickBG.rectTransform.position
                    + new Vector3(
                    (joystick.rectTransform.position.x - joystickBG.rectTransform.position.x)
                    * inputVector.magnitude
                    - (joystick.rectTransform.position.x - joystickBG.rectTransform.position.x),
                    (joystick.rectTransform.position.y - joystickBG.rectTransform.position.y)
                    * inputVector.magnitude
                    - (joystick.rectTransform.position.y - joystickBG.rectTransform.position.y), 0);

                inputVector = inputVector.normalized;
            }
            joystick.rectTransform.anchoredPosition = new Vector2(
                inputVector.x * (joystickBG.rectTransform.sizeDelta.x/16),
                inputVector.y * (joystickBG.rectTransform.sizeDelta.y/16));
        }
    }

    public void moveJoystick()
    {
        joystickBG.rectTransform.position = Input.mousePosition;
    }

    public float getHorizontal()
    {
        if (inputVector.x != 0) return inputVector.x;
        else return Input.GetAxis("Horizontal");
    }

    public float getVertical()
    {
        if (inputVector.y != 0) return inputVector.y;
        else return Input.GetAxis("Vertical");
    }
}
