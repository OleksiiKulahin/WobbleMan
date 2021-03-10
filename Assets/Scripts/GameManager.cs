using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool pause;
    public PlayerController pc;
    public LevelManager lm;
    public int money;
    public UIManager ui;

    public void Start()
    {
        pause = true;
        money = 0;
    }

    public bool getPause()
    {
        return pause;
    }

    public void changePause()
    {
        pause = !pause;
        pc.startSettings();
    }

    public void menuClick()
    {
        pause = !pause;
        pc.startSettings();
        if (pause) lm.restartLevel();
    }

    public void changeMoney(int value)
    {
        money += value;
        ui.updateMoney();
    }

    public int getMoney()
    {
        return money;
    }
}
