using UnityEngine;

public class PlateCollider : MonoBehaviour
{
    public GameObject target;
    public GameObject plate;
    public Material materialOn;
    public Material materialOff;

    public void OnTriggerStay(Collider collider)
    {
        target.SetActive(false);
        plate.GetComponent<MeshRenderer>().material = materialOn;
        plate.transform.position = new Vector3(plate.transform.position.x, 0.52f, plate.transform.position.z) ;
    }

    public void OnTriggerExit(Collider collider)
    {
        target.SetActive(true);
        plate.GetComponent<MeshRenderer>().material = materialOff;
        plate.transform.position = new Vector3(plate.transform.position.x, 0.6f, plate.transform.position.z);
    }

}
