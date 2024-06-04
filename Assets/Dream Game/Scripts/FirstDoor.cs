using System.Collections;
using UnityEngine;

namespace DoorScript
{
    [RequireComponent(typeof(AudioSource))]
    public class FirstDoor : Door
    {
        private bool canOpen = false;

        private void Start()
        {
            base.Start();
            StartCoroutine(EnableDoorAfterDelay(60f));
        }

        private IEnumerator EnableDoorAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            canOpen = true;
            OpenDoor();
        }

        private new void Update()
        {
            if (canOpen)
            {
                base.Update();
            }
        }

        public new void OpenDoor()
        {
            if (canOpen)
            {
                base.OpenDoor();
            }
            else
            {
                Debug.Log("This door cannot be opened during the first minute.");
            }
        }
    }
}
