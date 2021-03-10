using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{    
    public List<GameObject> levelList;
    public int level;
    public PlayerController pc;
    public UIManager ui;
    public GameManager gm;

    void Start()
    {
        level = 1;
        levelList.Add(Resources.Load("Prefabs/Levels/Level" + level) as GameObject);
    }

    public void nextLevel()
    {
        level++;
        gm.changeMoney(50);
        ui.openScreenWin();
        levelList.RemoveAt(0);
        levelList.Add(Resources.Load("Prefabs/Levels/Level"+level) as GameObject);
        Instantiate(levelList[0]).tag="Level";
        pc.startSettings();
    }

    public void loseLevel()
    {
        ui.openScreenLose();
        pc.startSettings();
        restartLevel();
    }

    public void restartLevel()
    {
        for (int i = 0; i < levelList.Count; i++)
        {
            levelList[i].GetComponent<Level>().ColliderEnemyEvent.Invoke();
        }
        Instantiate(levelList[0]).tag = "Level";
    }
}
