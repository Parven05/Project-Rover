using UnityEngine;

public class Mineral : MonoBehaviour
{
    [SerializeField] private MineralDataSO mineralDataSO;

    [SerializeField] private GameObject dustParticleGo;
    [SerializeField] private GameObject gloomParticleGo;

    public void SetActiveDustParticles(bool active)
    {
        dustParticleGo.SetActive(active);
    }

    public void SetActiveGloomParticles(bool active)
    {
        gloomParticleGo.SetActive(active);
    }
}

