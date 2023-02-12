using UnityEngine;
using System.Collections;


public class ButtonAction : MonoBehaviour
{

    public GameObject pointerObject;
    private bool habCanto = false;
    public GameObject puertaPuzzle1;
    void Start()
    {
        puertaPuzzle1.SetActive(false);
    }
    private void Update()
    {
        if(habCanto == true) { 
            if (Input.GetKeyDown(KeyCode.E))
            {
                Ray ray = new Ray(pointerObject.transform.position, pointerObject.transform.forward);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 5f))
                {
                    if (hit.collider.tag == "puerta roja")
                    {
                        Collider collider = hit.collider;
                        collider.enabled = false;

                        Renderer renderer = hit.collider.GetComponent<Renderer>();
                        StartCoroutine(FadeTo(renderer, 0f, 1f));
                    }
                }
            }
        }
    }

    IEnumerator FadeTo(Renderer renderer, float aValue, float aTime)
    {
        float alpha = renderer.material.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            renderer.material.color = newColor;
            yield return null;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "HabCanto")
        {
            habCanto = true;
            puertaPuzzle1.SetActive(true);
            Debug.Log("la puerta esta activa");
        }
    }

}
