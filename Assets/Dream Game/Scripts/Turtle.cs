using UnityEngine;

public class Turtle : MonoBehaviour
{
    public LevelController levelController;
    public NotificationHandler notificationHandler; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            levelController.SetTurtle(true);
 
            notificationHandler.ShowNotification("You found SKULLY! Now find a way to end this nightmare!!!");
            Destroy(gameObject);
        }
    }
}
