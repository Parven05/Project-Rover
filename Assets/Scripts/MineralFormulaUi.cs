using TMPro;
using UnityEngine;

public class MineralFormulaUi : MonoBehaviour
{
    public static MineralFormulaUi Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI mineralFormulaText;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        RoverPocketStorage.Instance.OnPocketStorageModified += RoverPocketStorage_Instance_OnPocketStorageModified;

        SetMineralFormulaName(string.Empty);
    }

    private void RoverPocketStorage_Instance_OnPocketStorageModified(MineralDataSO mineralDataSO)
    {
        SetMineralFormulaName(mineralDataSO ? mineralDataSO.mineralFormula : string.Empty);
    }

    public void SetMineralFormulaName(string mineralFormulaName)
    {
        mineralFormulaText.text = mineralFormulaName;
    }
}
