using UnityEngine;

public class ExitCollider : MonoBehaviour
{
    public Level parentLevel;
    private LevelManager lm;

    public void OnTriggerEnter(Collider collider)
    {
        print("OnTriggerEnter");
        lm = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        lm.nextLevel();
        parentLevel.ColliderLevelExitEvent.Invoke();
    }
}
