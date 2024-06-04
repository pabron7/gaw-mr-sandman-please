using UnityEngine;

public class Elephant : MonoBehaviour
{
    public LevelController levelController;
    public GameObject portal;
    public GameObject wayBack;
    public NotificationHandler notificationHandler; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            levelController.SetElephant(true);
            portal.SetActive(true);
            wayBack.SetActive(true);
            notificationHandler.ShowNotification("You found TOMMY! Now go back to your Room!!!");
            Destroy(gameObject);
        }
    }
}
