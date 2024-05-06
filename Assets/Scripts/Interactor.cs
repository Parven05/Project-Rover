using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private LayerMask inetractionLayer;
    [SerializeField] private float interactionRadius = 5f;

    private Collider[] colliders = new Collider[10];
    [Space]
    [SerializeField] private InteractorUi interactorUi;

    private int colliderCount;
    private void FixedUpdate()
    {
        colliderCount = Physics.OverlapSphereNonAlloc(transform.position, interactionRadius,colliders,inetractionLayer);

        interactorUi.SetActiveIndigation(colliderCount > 0);
    }

    private void Update()
    {
        if(colliderCount > 0)
        {
            if(Input.GetKey(KeyCode.E))
            {
                Collider collider = colliders[0];

                if (!collider) return;
                
                if(collider.gameObject.TryGetComponent(out IInteractable interactable))
                {
                    interactable.Interact();
                }
            }
        }
    }
}
