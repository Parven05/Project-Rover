using StarterAssets;
using UnityEngine;

public class Mineral : MonoBehaviour
{
    [SerializeField] private MineralDataSO mineralDataSO;

    [SerializeField] private GameObject dustParticleGo;
    [SerializeField] private GameObject gloomParticleGo;
    [SerializeField] private ParticleSystem pickUpParticleEffect;
    [SerializeField] private float mineralDestroyDelay = 1f;
    public void SetActiveDustParticles(bool active)
    {
        dustParticleGo.SetActive(active);
    }

    public void SetActiveGloomParticles(bool active)
    {
        gloomParticleGo.SetActive(active);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(collision.gameObject.name);   
        if (other.gameObject.TryGetComponent(out ThirdPersonController _))
        {
            pickUpParticleEffect.Play();

            MineralsFxManager.Instance.RemoveMineral(this);

            Destroy(gameObject, mineralDestroyDelay);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        
    }
}

