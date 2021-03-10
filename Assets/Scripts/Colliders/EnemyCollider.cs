using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    public Level parentLevel;
    private LevelManager _lm;

    public void OnTriggerEnter(Collider collider)
    {
        _lm = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        _lm.loseLevel();
        parentLevel.ColliderEnemyEvent.Invoke();
    }
}
