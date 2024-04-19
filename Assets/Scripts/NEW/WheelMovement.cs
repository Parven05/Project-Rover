using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class WheelMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public GameObject head;
    private Vector3 headOffset;

    private Rigidbody rb;

    private float moveHorizontal;
    private float moveVertical;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (head != null)
        {
            headOffset = head.transform.position - transform.position;
        }
    }

    private void Update()
    {
       moveHorizontal = Input.GetAxis("Horizontal");
       moveVertical = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        Vector3 moveDirection = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;

        rb.AddForce(moveDirection * moveSpeed, ForceMode.Acceleration);

        // If No Input From Player Means Stop Rover
        if(moveDirection.x == 0 && moveDirection.z == 0)
        {
            rb.velocity = Vector3.zero;
        }

        if (head != null)
        {
            Vector3 targetHeadPosition = transform.position + headOffset;
            head.transform.position = Vector3.Lerp(head.transform.position, targetHeadPosition, Time.deltaTime * moveSpeed);
        }
    }
}
