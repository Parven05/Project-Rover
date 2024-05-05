using UnityEngine;

public class RoverPocketStorage : MonoBehaviour
{
    public static RoverPocketStorage Instance { get; private set; }

    private MineralDataSO pickedMineralDataSO;

    private void Awake()
    {
        Instance = this;
    }

    public void SetPickedMineral(MineralDataSO pickedMineralDataSO)
    {
        this.pickedMineralDataSO = pickedMineralDataSO;
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
