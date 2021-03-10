using UnityEngine;

public class ExitCollider : MonoBehaviour
{
    public Level parentLevel;
    private LevelManager _lm;

    public void OnTriggerEnter(Collider collider)
    {
        _lm = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        parentLevel.ColliderLevelExitEvent.Invoke();
        _lm.nextLevel();
    }
}
