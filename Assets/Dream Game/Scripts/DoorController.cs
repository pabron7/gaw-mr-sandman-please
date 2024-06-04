using UnityEngine;

public class DoorController : MonoBehaviour
{
    public string playerTag = "Player"; // Tag to identify the player
    public KeyCode interactKey = KeyCode.E; // Key to interact with the gate
    private bool isPlayerNearby = false; // Flag to check if player is near the gate
    private bool isGateOpen = false; // Flag to check if the gate is already open
    public float rotationAngle = 90f; // Angle to rotate the gate
    public float rotationSpeed = 2f; // Speed of the rotation

    private Quaternion targetRotation; // Target rotation of the gate

    void Start()
    {
        targetRotation = transform.rotation; // Initial rotation
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(interactKey))
        {
            ToggleGate();
            Debug.Log("Toggle gate is called");
        }

        // Smoothly rotate towards the target rotation
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            isPlayerNearby = true;
            // Display a message or UI element to inform the player they can interact
            Debug.Log("The player is nearby, door can be opened.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            isPlayerNearby = false;
            // Hide the interaction message or UI element
            Debug.Log("The player is gone, door can't be opened.");
        }
    }

    private void ToggleGate()
    {
        if (isGateOpen)
        {
            // Close the gate by rotating it back to the original rotation
            targetRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y - rotationAngle, transform.eulerAngles.z);
        }
        else
        {
            // Open the gate by rotating it by the specified angle
            targetRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + rotationAngle, transform.eulerAngles.z);
        }

        isGateOpen = !isGateOpen; // Toggle the gate state
    }
}
