using UnityEngine;

public class HeadVisual : MonoBehaviour
{
    [SerializeField] private float headMoveSpeed = 5.0f;
    [SerializeField] private GameObject head;
    private Vector3 headOffset;

    private void Start()
    {
        if (head != null)
        {
            headOffset = head.transform.position - transform.position;
        }
    }

    private void FixedUpdate()
    {
        if (head != null)
        {
            Vector3 targetHeadPosition = transform.position + headOffset;
            head.transform.position = Vector3.Lerp(head.transform.position, targetHeadPosition, Time.deltaTime * headMoveSpeed);
        }
    }
}
