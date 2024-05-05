using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MineralDeliveryUi : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI mineralCountText;

    private void Start()
    {
        MineralDeliveryArea.Instance.OnMineralListModified += MineralDeliveryArea_MineralListModified;
    }

    private void MineralDeliveryArea_MineralListModified(List<MineralDataSO> list)
    {
        UpdateMineralCount(list);
    }

    private void UpdateMineralCount(List<MineralDataSO> list)
    {
        mineralCountText.text = $"Collected Minerals {list.Count}/{MineralDeliveryArea.Instance.GetTotalCollectableMineralsCount()}";
    }
}
