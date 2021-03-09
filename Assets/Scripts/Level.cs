using UnityEngine;
using UnityEngine.Events;

public class Level : MonoBehaviour
{
    public UnityEvent ColliderLevelExitEvent;

    public void onColliderLevelExitEvent()
    {
        if (ColliderLevelExitEvent != null)
        {
            print("onColliderLevelExitEvent");
            Destroy(GameObject.FindGameObjectWithTag("Level"));
        }
    }
}
