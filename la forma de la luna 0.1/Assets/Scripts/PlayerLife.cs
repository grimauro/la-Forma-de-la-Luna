using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public float maxLife = 100f;
    public float damagePerSecond = 5f;
    private float currentLife;
    private bool isInDangerZone;

    private void Start()
    {
        currentLife = maxLife;
    }

    private void Update()
    {
        if (isInDangerZone)
        {
            currentLife -= damagePerSecond * Time.deltaTime;
        }
        Debug.Log(currentLife);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Peligro")
        {
            isInDangerZone = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Peligro")
        {
            isInDangerZone = false;
        }
    }
}
