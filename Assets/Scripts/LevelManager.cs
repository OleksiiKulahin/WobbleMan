using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{    
    public List<GameObject> levelList;
    public int level;
    public PlayerController pc;
    public UIManager ui;

    void Start()
    {
        level = 1;
        levelList.Add(Resources.Load("Prefabs/Levels/Level" + level) as GameObject);
    }

    public void nextLevel()
    {
        print("level up");
        if (level != 3) level++;
        ui.openScreenWin();
        levelList.RemoveAt(0);
        levelList.Add(Resources.Load("Prefabs/Levels/Level"+level) as GameObject);
        Instantiate(levelList[0]).tag="Level";
        pc.startSettings();
    }

    public void loseLevel()
    {
        ui.openScreenLose();
        Instantiate(levelList[0]).tag = "Level";
        pc.startSettings();
    }
}
