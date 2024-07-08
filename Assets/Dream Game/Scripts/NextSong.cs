
using UnityEngine.UI;
using UnityEngine;

public class NextSong : MonoBehaviour
{
    void Awake()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(PlayNextSong);
        }
    }

    void PlayNextSong()
    {
        MusicManager.Instance.NextSong();
    }
}
