using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool pause;
    public PlayerController pc;

    public bool getPause()
    {
        return pause;
    }

    public void Start()
    {
        pause = true;
    }

    public void changePause()
    {
        pause = !pause;
        pc.startSettings();
    }
}
