using UnityEngine;
using FMODUnity;

public class ZoneDetector : MonoBehaviour
{
    public float floorCheckDistance = 1.0f;
    public GameObject floor;

    FMODUnity.StudioEventEmitter FmodEventEsfera;



    void Start()
    {
        FmodEventEsfera = GetComponent<FMODUnity.StudioEventEmitter>();


        //eventInstance = FMODUnity.RuntimeManager.CreateInstance(eventPath);
        //eventInstance.getParameterByName("zoneDetector", out zoneDetector);
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
                    FmodEventEsfera.EventInstance.setParameterByName("zoneDetector", 0);
                    break;
                case "zonaRuido0":
                    FmodEventEsfera.EventInstance.setParameterByName("zoneDetector", 1);
                    break;
                case "zonaAire0":
                    FmodEventEsfera.EventInstance.setParameterByName("zoneDetector", 2);
                    break;
                case "zonaPuzzle1.1":
                    FmodEventEsfera.EventInstance.setParameterByName("zoneDetector", 3);
                    break;
                case "zonaPuzzle1.2":
                    FmodEventEsfera.EventInstance.setParameterByName("zoneDetector", 4);
                    break;
                case "zonaCheckpoint0":
                    FmodEventEsfera.EventInstance.setParameterByName("zoneDetector", 3);
                    break;

            }
        }
    }
}