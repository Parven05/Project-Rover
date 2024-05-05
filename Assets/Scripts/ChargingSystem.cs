using UnityEngine;

public class ChargingSystem : MonoBehaviour
{
    [SerializeField] private SolarPanelUi solarPanel;
    [SerializeField] private float chargingSpeed = 0.3f;

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Rover _))
        {
            solarPanel.AddPower(Time.deltaTime * chargingSpeed);
        }
    }
}
