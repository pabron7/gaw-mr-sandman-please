
using UnityEngine;

public class MusicTrigger : MonoBehaviour
{
    public int index;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MusicManager.Instance.PlaySongAtIndex(index);
            Destroy(gameObject);
        }
    }
}
