using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float mouseSensitivity = 100.0f;
    public Transform cameraTransform;


    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cameraTransform = transform.GetChild(0);
    }

    private void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 newPosition = transform.position + (cameraTransform.forward * vertical + cameraTransform.right * horizontal) * speed * Time.deltaTime;
        newPosition.y = transform.position.y; //set the y position to the original y position
        transform.position = newPosition;

        rotationX -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        rotationY += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        rotationX = Mathf.Clamp(rotationX, -90, 90);

        transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0.0f);


    }

    private void OnTriggerEnter(Collider other)
    {
        // Código para manejar la colisión con otro collider
        Debug.Log("Entró en contacto con " + other.gameObject.name);
    }
}
