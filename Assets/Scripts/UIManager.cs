using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject buttonStart;
    public GameObject buttonMenu;
    public GameManager gm;

    public void Update()
    {
        changePause();
    }

    public void changePause()
    {
        buttonStart.SetActive(gm.getPause());
        buttonMenu.SetActive(!gm.getPause());
    }
}
