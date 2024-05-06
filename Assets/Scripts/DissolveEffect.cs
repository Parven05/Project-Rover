using System.Collections;
using UnityEngine;

public class DissolveEffect : MonoBehaviour
{
    [SerializeField] private Material dissolveMaterial;

    [SerializeField] private float dissolveSpeed = 0.5f;
    [SerializeField] private float dissolveTarget = 1f;
                     private float sliceAmount = 0f;

    public void StartDisolve(MeshRenderer meshRenderer)
    {
        meshRenderer.material = dissolveMaterial;

        sliceAmount = 0f;

        StartCoroutine(Dissolve());
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
    }
}
