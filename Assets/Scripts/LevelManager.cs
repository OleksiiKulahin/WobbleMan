using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{    
    public List<GameObject> levelList;
    public int level;
    private PlayerController pc;

    void Start()
    {
        level = 1;
    }

    public void nextLevel()
    {
        level++;
        print(level);
        levelList.Add(Resources.Load("Levels/Level2") as GameObject);
        levelList.RemoveAt(0);
        Instantiate(levelList[0]).tag="Level";
        pc.transform.position = new Vector3(0,1.5f,0);
    }
}
