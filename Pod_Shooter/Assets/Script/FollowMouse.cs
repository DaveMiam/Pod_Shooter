using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FollowMouse : NetworkBehaviour {
    [SerializeField] GameObject gun;
    [SerializeField] Camera playerCamera;
    [SerializeField] GameObject player;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if(isLocalPlayer)
        {
            if (Input.GetAxis("Mouse X") != 0)
            {
                player.transform.Rotate(0, Input.GetAxis("Mouse X") * 25, 0);

            }
            if (Input.GetAxis("Mouse Y") != 0)
            {
                playerCamera.transform.Rotate(-Input.GetAxis("Mouse Y") * 5, 0, 0);
                gun.transform.Rotate(-Input.GetAxis("Mouse Y") * 5, 0, 0);
                playerCamera.transform.Translate(0, -Input.GetAxis("Mouse Y") * 0.1f, 0);
            }
        }
        
    }
}
