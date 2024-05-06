using StarterAssets;
using System.Collections;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class Mineral : MonoBehaviour
{
    [SerializeField] private MineralDataSO mineralDataSO;
    [Space]
    [SerializeField] private GameObject dustParticleGo;
    [SerializeField] private GameObject gloomParticleGo;
    [SerializeField] private Material dissolveMaterial;

    [SerializeField] private TextMeshProUGUI mineralFormulaText;

    [Space]
    [SerializeField] private float mineralDestroyDelay = 1f;

    private bool isDissolving = false;
    private float dissolveSpeed = 0.5f;
    private float dissolveTarget = 1f;

    private float sliceAmount = 0f;

    public void SetActiveDustParticles(bool active)
    {
        dustParticleGo.SetActive(active);
    }

    public void SetActiveGloomParticles(bool active)
    {
        gloomParticleGo.SetActive(active);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out ThirdPersonController _) && !RoverPocketStorage.Instance.IsHoldingMineral() && !isDissolving)
        {
            isDissolving = true;
            sliceAmount = 0f;
            StartCoroutine(Dissolve());

            // Access formula text & convert into UI in game
            mineralFormulaText.text = mineralDataSO.mineralFormula;

            // Remove this mineral from the manager
            MineralsFxManager.Instance.RemoveMineral(this);

            // Set the picked mineral
            RoverPocketStorage.Instance.SetPickedMineral(mineralDataSO);

            // Destroy this mineral after a delay
            Destroy(gameObject, mineralDestroyDelay);
        }
    }

    private IEnumerator Dissolve()
    {
        while (sliceAmount < dissolveTarget)
        {
            sliceAmount = Mathf.Lerp(sliceAmount, dissolveTarget, dissolveSpeed * Time.deltaTime);
            dissolveMaterial.SetFloat("_SliceAmount", sliceAmount);
            yield return null;
        }

        sliceAmount = dissolveTarget;
        dissolveMaterial.SetFloat("_SliceAmount", sliceAmount);

        isDissolving = false; // Reset the dissolution flag
    }

    // Ensure isDissolving is reset when the mineral is destroyed
    private void OnDestroy()
    {
        // If the mineral is destroyed while dissolving, reset isDissolving
        if (isDissolving)
        {
            isDissolving = false;
        }
    }
}
