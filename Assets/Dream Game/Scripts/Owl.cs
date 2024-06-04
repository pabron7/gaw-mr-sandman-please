using UnityEngine;

public class Owl : MonoBehaviour
{
    public LevelController levelController;
    public NotificationHandler notificationHandler;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            levelController.SetOwl(true);

            notificationHandler.ShowNotification("You found GINNY! Now keep going to find Tommy!!!");
            Destroy(gameObject);
        }
    }
}
    