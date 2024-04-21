using StarterAssets;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SolarPanelUi : MonoBehaviour
{
    [SerializeField] private List<Image> solarBarImageList;
    [SerializeField] private float soloarPowerDecreaseSpeed = 2f;
    [SerializeField] private float soloarPowerIncreaseSpeed = 2f;

    [Space]
    private float currentSolorPower;
    private const float solarPowerMax = 100;

    private float perBatteryPercentage;
    private bool isRoverMoving = false;

    [SerializeField] private ThirdPersonController tpController;
    [SerializeField] private ChargeMode chargeMode;
    public enum ChargeMode { AutoCharge,ManualStation }
    private void Awake()
    {
        currentSolorPower = solarPowerMax;
        perBatteryPercentage = solarPowerMax / solarBarImageList.Count;
    }

    private void Update()
    {
        if(tpController) isRoverMoving = tpController.IsRoverMoving();

        if(isRoverMoving)
        {
            currentSolorPower -= Time.deltaTime * soloarPowerDecreaseSpeed;
        }
        else
        {
            if(chargeMode == ChargeMode.AutoCharge)
            currentSolorPower += Time.deltaTime * soloarPowerIncreaseSpeed;
        }

        currentSolorPower = Mathf.Clamp(currentSolorPower, 0, solarPowerMax);
        HandleSolarBarUi();
    }

    private void HandleSolarBarUi()
    {
        // Calculate the number of bars to disable based on the current solar power
        int barsToDisable = Mathf.FloorToInt((solarPowerMax - currentSolorPower) / perBatteryPercentage);

        // Disable excess bars
        for (int i = 0; i < solarBarImageList.Count; i++)
        {
            if (i < barsToDisable)
            {
                solarBarImageList[i].enabled = false;
            }
            else
            {
                solarBarImageList[i].enabled = true;
            }
        }
    }
}
