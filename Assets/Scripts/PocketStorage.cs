using UnityEngine;

public class PocketStorage : MonoBehaviour
{
    [SerializeField] private Mineral pickedMineral;

    public void SetPickedMineral(Mineral pickedMineral)
    {
        this.pickedMineral = pickedMineral;
    }
}
