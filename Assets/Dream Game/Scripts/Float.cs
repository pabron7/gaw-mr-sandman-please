using UnityEngine;

public class Float : MonoBehaviour
{
    public float amplitude = 0.5f; 
    public float frequency = 1f; 

    private Vector3 startPosition;
    private Rigidbody rb;

    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
        rb.useGravity = false;
        rb.isKinematic = true; 
    }

    void FixedUpdate()
    {
        Floating();
    }

    void Floating()
    {
        float newY = startPosition.y + amplitude * Mathf.Sin(Time.time * frequency);
        Vector3 newPosition = new Vector3(startPosition.x, newY, startPosition.z);

        rb.MovePosition(newPosition);
    }
}