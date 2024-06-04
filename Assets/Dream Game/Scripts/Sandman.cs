using UnityEngine;
using System.Collections;

public class Sandman : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component
    public GameObject spriteObject; // The GameObject containing the sprite

    private void Start()
    {
        // Start the visibility animation
        if (animator != null)
        {
            animator.Play("Sandman");
        }

        // Start the coroutine to hide the sprite at the 60th second
        StartCoroutine(HideSpriteAfterDelay(60f));
    }

    private IEnumerator HideSpriteAfterDelay(float delay)
    {
        // Wait for the specified delay (60 seconds)
        yield return new WaitForSeconds(delay);

        // Hide the sprite by setting it inactive
        if (spriteObject != null)
        {
            spriteObject.SetActive(false);
        }
    }
}
