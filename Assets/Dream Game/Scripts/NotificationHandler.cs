using UnityEngine;
using TMPro;

public class NotificationHandler : MonoBehaviour
{
    public float displayDuration = 2f; 

    private TextMeshProUGUI notificationText;

    private void Awake()
    {
        notificationText = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        Invoke("HideNotification", displayDuration);
    }

    public void ShowNotification(string message)
    {
        notificationText.text = message;
        gameObject.SetActive(true);
    }

    private void HideNotification()
    {
        gameObject.SetActive(false);
    }
}
