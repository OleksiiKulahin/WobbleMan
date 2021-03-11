using UnityEngine;

public class Item : MonoBehaviour
{
    private GameManager _gm;

    public void Start()
    {
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (name.Contains("Money")&& collider.tag=="Player")
        {
            Destroy(gameObject);
            _gm.changeMoney(10);
        }
    }
}
