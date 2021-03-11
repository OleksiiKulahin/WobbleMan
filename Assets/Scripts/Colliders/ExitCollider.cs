using UnityEngine;

public class ExitCollider : MonoBehaviour
{
    public Level parentLevel;
    private LevelManager _lm;

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            _lm = GameObject.Find("LevelManager").GetComponent<LevelManager>();
            _lm.nextLevel();
            parentLevel.ColliderLevelExitEvent.Invoke();
        }
    }
}
