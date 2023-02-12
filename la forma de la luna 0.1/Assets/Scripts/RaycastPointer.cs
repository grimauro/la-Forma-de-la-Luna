using UnityEngine;

public class RaycastPointer : MonoBehaviour
{
    public float distance = 100f;
    public GameObject pointer;

    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distance))
        {
            pointer.SetActive(true);
            pointer.transform.position = hit.point;
        }
        else
        {
            pointer.SetActive(false);
        }
    }
}