using StarterAssets;
using System;
using UnityEngine;

public class Mineral : MonoBehaviour
{
    [SerializeField] private MineralDataSO mineralDataSO;
    [Space]
    [SerializeField] private GameObject dustParticleGo;
    [SerializeField] private GameObject gloomParticleGo;
    [SerializeField] private ParticleSystem pickUpParticleEffect;
    [Space]
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
        
    }

    private void OnCollisionEnter(Collision other)
    {
        //Debug.Log(collision.gameObject.name);   
        if (other.gameObject.TryGetComponent(out ThirdPersonController _) && !RoverPocketStorage.Instance.IsHoldingMineral())
        {
            pickUpParticleEffect.Play();

            MineralsFxManager.Instance.RemoveMineral(this);

            RoverPocketStorage.Instance.SetPickedMineral(mineralDataSO);

            Destroy(gameObject, mineralDestroyDelay);
        }
    }
}

