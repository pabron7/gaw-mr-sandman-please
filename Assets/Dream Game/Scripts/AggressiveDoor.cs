using System.Collections;
using UnityEngine;

namespace DoorScript
{
    [RequireComponent(typeof(AudioSource))]
    public class AggressiveDoor : MonoBehaviour
    {
        public bool open;
        public float smooth = 1.0f;
        private float DoorOpenAngle = -90.0f;
        private float DoorCloseAngle = 0.0f;
        public AudioSource asource;
        public AudioClip openDoor, closeDoor;

        public float minInterval = 0.52f;
        public float maxInterval = 1f; 

        private void Start()
        {
            asource = GetComponent<AudioSource>();
            StartCoroutine(OpenCloseCycle());
        }

        private void Update()
        {
            if (open)
            {
                var target = Quaternion.Euler(0, DoorOpenAngle, 0);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime * 5 * smooth);
            }
            else
            {
                var target1 = Quaternion.Euler(0, DoorCloseAngle, 0);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, target1, Time.deltaTime * 5 * smooth);
            }
        }

        public void OpenDoor()
        {
            open = !open;
            asource.clip = open ? openDoor : closeDoor;
            asource.Play();
        }

        private IEnumerator OpenCloseCycle()
        {
            while (true)
            {
                OpenDoor();
                float randomInterval = Random.Range(minInterval, maxInterval);
                yield return new WaitForSeconds(randomInterval);
            }
        }
    }
}
