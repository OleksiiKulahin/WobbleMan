using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject buttonStart;
    public GameObject buttonMenu;
    public GameObject screenWin;
    public GameObject screenLose;
    public GameObject level;
    public GameObject money;
    public GameManager gm;
    public LevelManager lm;

    public void Update()
    {
        changePause();
    }

    public void changePause()
    {
        buttonStart.SetActive(gm.getPause());
        buttonMenu.SetActive(!gm.getPause());
    }

    public void openScreenWin()
    {
        level.SetActive(false);
        money.SetActive(false);
        gm.changePause();
        screenWin.SetActive(true);
        screenWin.transform.GetChild(1).GetComponent<Text>().text = "Level " + (lm.level-1) + " is completed!";
        level.GetComponent<Text>().text = "Floor " + lm.level;
    }

    public void closeScreenWin()
    {
        screenWin.SetActive(false);
        level.SetActive(true);
        money.SetActive(true);
    }

    public void openScreenLose()
    {
        gm.changePause();
        screenLose.SetActive(true);
        level.SetActive(false);
        money.SetActive(false);
    }

    public void closeScreenLose()
    {
        screenLose.SetActive(false);
        level.SetActive(true);
        money.SetActive(true);
    }

    public void updateMoney()
    {
        money.GetComponent<Text>().text = "Money: " + gm.getMoney();
    }
}
