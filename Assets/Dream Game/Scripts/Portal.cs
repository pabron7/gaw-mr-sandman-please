using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Player player;
    public bool PortalOpen;
    public Transform PortalVirCamPos;
    public Transform OtherSidePortal;
    public Transform OtherSidePov;
    private bool playerIsOverlapping = false;

    void Start()
    {
        if (player == null)
        {
            player = FindObjectOfType<Player>();
        }
    }

    void LateUpdate()
    {
        if (PortalOpen)
        {
            Matrix4x4 m = OtherSidePov.localToWorldMatrix * transform.worldToLocalMatrix * player.transform.localToWorldMatrix;

            PortalVirCamPos.SetPositionAndRotation(m.GetColumn(3), m.rotation);
            if (playerIsOverlapping)
            {
                Vector3 portalToPlayer = player.transform.position - transform.position;
                float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

                if (dotProduct < 0f)
                {
                    //  player.GetComponent<CharacterController>().enabled = false;
                    float rotationDiff = -Quaternion.Angle(transform.rotation, OtherSidePortal.rotation);
                    rotationDiff += 180;
                    player.transform.Rotate(Vector3.up, rotationDiff);

                    Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                    player.transform.position = OtherSidePortal.position + positionOffset;
                    //  player.GetComponent<CharacterController>().enabled = true;

                    print("tp");
                    playerIsOverlapping = false;
                }

            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = false;
        }
    }

}