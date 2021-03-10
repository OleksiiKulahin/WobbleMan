using UnityEngine;
using UnityEngine.Events;

public class Level : MonoBehaviour
{
    public UnityEvent ColliderLevelExitEvent;
    public UnityEvent ColliderEnemyEvent;

    public void onColliderLevelExitEvent()
    {
        if (ColliderLevelExitEvent != null)
        {
            Destroy(GameObject.FindGameObjectWithTag("Level"));
        }
    }

    public void onColliderEnemyEvent()
    {
        if (ColliderLevelExitEvent != null)
        {
            Destroy(GameObject.FindGameObjectWithTag("Level"));
        }
    }
}
