using StarterAssets;
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

    private void OnTriggerEnter(Collider other)
    {
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.name);   
        if (collision.gameObject.TryGetComponent(out ThirdPersonController _))
        {
            Transform pickEffect = Instantiate(mineralDataSO.mineralPickParticle, transform).transform;
            pickEffect.transform.localPosition = Vector3.zero;

            ParticleSystem particleSystem = pickEffect.GetComponent<ParticleSystem>();
            particleSystem.Play();

            MineralsFxManager.Instance.RemoveMineral(this);

            Destroy(gameObject, mineralDataSO.pickUpDestroyDelay);
        }
    }
}

