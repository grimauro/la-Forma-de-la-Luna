using UnityEngine;

public class CustomPolygonCollider : Collider
{
    // Valores que representan la forma y la posición del collider
    public Vector3[] points;

    private Vector2[] _points2D;

    private void Awake()
    {
        // Convertir los puntos en una forma que pueda ser utilizada por el collider
        _points2D = new Vector2[points.Length];
        for (int i = 0; i < points.Length; i++)
        {
            _points2D[i] = new Vector2(points[i].x, points[i].z);
        }
    }

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
        // Código para manejar la colisión con otro collider
        Debug.Log("Entró en contacto con " + other.gameObject.name);
    }
}