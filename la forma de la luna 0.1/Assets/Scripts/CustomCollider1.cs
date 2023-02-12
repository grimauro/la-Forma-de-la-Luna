using UnityEngine;

public class CustomCollider1 : MonoBehaviour
{
    // Valores que representan la forma y la posici�n del collider
    public Vector3[] points;

    private void OnDrawGizmos()
    {
        // Dibujar el collider en la escena utilizando los puntos especificados
        Gizmos.color = Color.red;
        for (int i = 0; i < points.Length; i++)
        {
            Vector3 pointA = transform.TransformPoint(points[i]);
            Vector3 pointB = transform.TransformPoint(points[(i + 1) % points.Length]);
            Gizmos.DrawLine(pointA, pointB);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // C�digo para manejar la colisi�n con otro collider
        Debug.Log("Entr� en contacto con " + other.gameObject.name);
    }
}