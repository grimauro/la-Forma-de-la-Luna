using UnityEngine;
using FMODUnity;

public class ZoneDetector : MonoBehaviour
{
    public float floorCheckDistance = 1.0f;
    public GameObject floor;

    public string eventPath;
    private FMOD.Studio.EventInstance eventInstance;
    private FMOD.Studio.ParameterInstance zoneDetector;
    // private FMOD.Studio.EventEmitter zoneDetector;


    void Start()
    {
        eventInstance = FMODUnity.RuntimeManager.CreateInstance(eventPath);
        eventInstance.getParameter("zoneDetector", out zoneDetector);
    }

    private void Update()
    {
        // Disparar un rayo hacia abajo para detectar el piso debajo del jugador
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, floorCheckDistance))
        {
            // Obtener el objeto que representa el piso debajo del jugador
            GameObject floor = hitInfo.collider.gameObject;
            Debug.Log("Estás en la zona: " + floor.name);

            switch (floor.name)
            {
                case "zonaInicial":
                    zoneDetector.setValue(0);
                    break;
                case "zonaRuido0":
                    zoneDetector.setValue(1);
                    break;
                case "zonaAire0":
                    zoneDetector.setValue(2);
                    break;
                case "zonaPuzzle1.1":
                    zoneDetector.setValue(3);
                    break;
                case "zonaPuzzle1.2":
                    zoneDetector.setValue(4);
                    break;
                case "zonaCheckpoint0":
                    zoneDetector.setValue(3);
                    break;
                    
            }
        }
    }
}