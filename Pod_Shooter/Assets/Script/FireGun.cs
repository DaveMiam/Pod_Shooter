using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FireGun : NetworkBehaviour {
    [SerializeField] GameObject Bullet;
    [SerializeField] GameObject BulletEmiter;
    [SerializeField] float fireRate = 1;
    // Use this for initialization
    private float timerLastShot = 0;
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if(isLocalPlayer)
        {
            timerLastShot += Time.deltaTime;
            if (timerLastShot > fireRate)
            {
                var fire1 = Input.GetAxis("Fire1");
                if (fire1 > 0)
                {
                    CmdFire();
                    timerLastShot = 0;
                }
            }
        }
    }

    [Command]
    void CmdFire()
    {
       GameObject bullet  = Instantiate(Bullet, BulletEmiter.transform.position, BulletEmiter.transform.rotation);
        NetworkServer.Spawn(bullet);
    }
}
