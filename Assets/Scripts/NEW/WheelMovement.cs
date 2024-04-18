using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class WheelMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public GameObject head;
    private Vector3 headOffset;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (head != null)
        {
            headOffset = head.transform.position - transform.position;
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;

        rb.AddForce(moveDirection * moveSpeed, ForceMode.Acceleration);

        if (head != null)
        {
            Vector3 targetHeadPosition = transform.position + headOffset;
            head.transform.position = Vector3.Lerp(head.transform.position, targetHeadPosition, Time.deltaTime * moveSpeed);
        }
    }
}
