using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonStart : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public Event buttonStartEvent;
    public JoystickController jc;
    public GameManager gm;

    public virtual void OnDrag(PointerEventData eventData)
    {
        jc.OnDrag(eventData);
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        jc.OnPointerDown(eventData);
        gm.changePause();
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        jc.OnPointerUp(eventData);
    }
}
