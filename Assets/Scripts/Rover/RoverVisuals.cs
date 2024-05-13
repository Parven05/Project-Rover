using StarterAssets;
using UnityEngine;

public class RoverVisuals : MonoBehaviour
{
    [SerializeField] private ParticleSystem dustParticles;
    private ThirdPersonController thirdPersonController;
    private bool isMoving = false;
    private void Awake()
    {
        thirdPersonController = GetComponent<ThirdPersonController>();
    }
    private void Update()
    {
        isMoving = thirdPersonController.IsRoverMoving();

        if (isMoving)
        {
            if(!dustParticles.isPlaying)
            {
                dustParticles.Play();
            }
        }
        else
        {
            if(dustParticles.isPlaying)
            {
                dustParticles.Stop();
            }
        }
    }
}
