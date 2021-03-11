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
    }

    public void nextLevel()
    {
        if(level<3)level++;
        gm.changeMoney(levelList[0].GetComponent<Level>().moneyForLevel);
        ui.openScreenWin();
        levelList.RemoveAt(0);
        levelList.Add(Resources.Load("Prefabs/Levels/Level"+level) as GameObject);
        if (levelList[0]!=null)
        {
            Instantiate(levelList[0]).tag = "Level";
        }
        else
        {
            Debug.Log("Out of levels");
            return;
        }
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
            levelList.RemoveAt(i);
        }
        levelList.Add(Resources.Load("Prefabs/Levels/Level" + level) as GameObject);
        Instantiate(levelList[0]).tag = "Level";
    }
}
