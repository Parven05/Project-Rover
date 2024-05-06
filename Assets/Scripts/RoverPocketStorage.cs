using System;
using UnityEngine;

public class RoverPocketStorage : MonoBehaviour
{
    public static RoverPocketStorage Instance { get; private set; }

    public event Action<MineralDataSO> OnPocketStorageModified;

    private MineralDataSO pickedMineralDataSO;

    private void Awake()
    {
        Instance = this;
    }

    public void SetPickedMineral(MineralDataSO pickedMineralDataSO)
    {
        this.pickedMineralDataSO = pickedMineralDataSO;

        OnPocketStorageModified?.Invoke(pickedMineralDataSO);
    }

    public MineralDataSO GetPickedMineralDataSO()
    {
        return this.pickedMineralDataSO;
    }

    public bool IsHoldingMineral()
    {
        return pickedMineralDataSO != null;
    }
}
