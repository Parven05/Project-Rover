using UnityEngine;
using UnityEngine.UI;

public class InteractorUi : MonoBehaviour
{
    [SerializeField] private Image interactionImage;

    public void SetActiveIndigation(bool activeIndigation)
    {
        if (interactionImage != null)
        {
            interactionImage.enabled = activeIndigation;
        }
    }
}
