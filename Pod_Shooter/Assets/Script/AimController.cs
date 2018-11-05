using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class AimController : NetworkBehaviour
{
    bool isAiming = false;
    [SerializeField] GameObject aimedTargetLocation;
    [SerializeField] GameObject unaimedTargetLocation;
    [SerializeField] float timeToAim=1f;
    [SerializeField] float aimedFieldOfView = 30;
    [SerializeField] float unaimedFiledOfView = 60;
    [SerializeField] Camera playerCamera;

    private float progression = 0;
    private float calculatedTime = 0;
    private GameObject currentTargetLocation;

    private void Start() {
        currentTargetLocation = unaimedTargetLocation;
    }

    void Update () {
        if(isLocalPlayer)
        {
            if (Input.GetAxis("Fire2") > 0)
            {
                AjustProgression(true);
            }
            else
            {
                AjustProgression(false);
            }
        }

       

	}
    private void AjustProgression(bool isAiming) {
        if (isAiming) {
            calculatedTime += Time.deltaTime;
            calculatedTime = Mathf.Min(calculatedTime, 1);
            progression = calculatedTime / timeToAim;
            currentTargetLocation = aimedTargetLocation;
        } else {
            calculatedTime -= Time.deltaTime;
            calculatedTime = Mathf.Max(calculatedTime, 0);
            progression = calculatedTime / timeToAim;
            currentTargetLocation = unaimedTargetLocation;
        }
        AjustCameraPosition();
        AjustCameraFieldOfView();
    }

    private void AjustCameraPosition () {
        playerCamera.transform.position = Vector3.Lerp(playerCamera.transform.position, currentTargetLocation.transform.position, progression);
    }

    private void AjustCameraFieldOfView() {
        playerCamera.fieldOfView = unaimedFiledOfView - (progression * (unaimedFiledOfView-aimedFieldOfView));
    }
}
