using System.Collections.Generic;
using UnityEngine;

public class MineralsFxManager : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    [SerializeField] private List<Mineral> minerals;

    [SerializeField] private float dustIndigationDistance = 5f;
    [SerializeField] private float gloomIndigationDistance = 10f;

    private void Update()
    {
        foreach (Mineral mineral in minerals)
        {
            if(Vector3.Distance(mineral.transform.position,playerTransform.position) < dustIndigationDistance)
            {
                mineral.SetActiveDustParticles(true);
            }
            else
            {
                mineral.SetActiveDustParticles(false);
            }

            if (Vector3.Distance(mineral.transform.position, playerTransform.position) < gloomIndigationDistance)
            {
                mineral.SetActiveGloomParticles(true);
            }
            else
            {
                mineral.SetActiveGloomParticles(false);
            }
        }
    }
}
