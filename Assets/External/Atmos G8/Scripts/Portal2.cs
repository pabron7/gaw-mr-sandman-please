using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal2 : MonoBehaviour
{
    public Player player;
    public bool PortalOpen;
    public Transform PortalVirCamPos;
    public Transform OtherSidePortal;
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
            Matrix4x4 m = OtherSidePortal.localToWorldMatrix * transform.worldToLocalMatrix * player.transform.localToWorldMatrix;
            
            PortalVirCamPos.SetPositionAndRotation(m.GetColumn(3), m.rotation);

            //Vector3 _pVCDirection = player.PlayerCamPos.forward;
            //PortalVirCamPos.rotation = Quaternion.LookRotation(new Vector3(-_pVCDirection.x, _pVCDirection.y, -_pVCDirection.z));

            //float angularDiffBetweenPortals = Quaternion.Angle(PortalVirCamPos.rotation, player.PortalPos.rotation);
            //Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDiffBetweenPortals, Vector3.up);
            //Vector3 newCameraDirection = portalRotationalDifference * player.PlayerCamPos.forward;
            //PortalVirCamPos.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
        }
    }
}