using UnityEngine;

public class Mineral : MonoBehaviour,IInteractable
{
    [SerializeField] private MineralDataSO mineralDataSO;
    [Space]
    [SerializeField] private GameObject dustParticleGo;
    [SerializeField] private GameObject gloomParticleGo;
    [Space]
    [SerializeField] private float mineralDestroyDelay = 1f;
    private bool isInteracted = false;

    public void SetActiveDustParticles(bool active)
    {
        dustParticleGo.SetActive(active);
    }

    public void SetActiveGloomParticles(bool active)
    {
        gloomParticleGo.SetActive(active);
    }

    public void Interact()
    {
        if (!RoverPocketStorage.Instance.IsHoldingMineral() && !isInteracted)
        {
            GetComponent<DissolveEffect>().StartDisolve(GetComponent<MeshRenderer>());

            // Remove this mineral from the manager
            MineralsFxManager.Instance.RemoveMineral(this);

            // Destroy this mineral after a delay
            Destroy(gameObject, mineralDestroyDelay);

            isInteracted = true;
        }
    }

    private void OnDestroy()
    {
        SoundManager.Instance.PlayClipAtPosition("Pick_SFX",transform.position);

        RoverPocketStorage.Instance.SetPickedMineral(mineralDataSO);
    }
}
