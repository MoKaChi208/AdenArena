using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WeaponGun : NetworkBehaviour

{ 
    public GameObject bulletPrefabs;
    public Joystick joystick;
    

    private Vector3 moveVector;
    public float rotationSpeed = 720;
    private float nextTimeOfFire = 0;


     void Start()
    {
        joystick = joystick = GameObject.Find("Fixed Joystick Shoot").GetComponent<Joystick>();
    }

    void Update()
    {
        if (GetComponentInParent<Player>().isLocalPlayer)
        {
            moveVector = (Vector3.right * joystick.Horizontal + Vector3.up * joystick.Vertical);
            if (moveVector != Vector3.zero)
            {
                if (Time.time >= nextTimeOfFire)
                {
                    CmdShot();
                    nextTimeOfFire = Time.time + 1 / 0.9f;
                }

            }
        }
    }
    

    [Command]
    public void CmdShot()
    {
        Transform firePoint = GameObject.Find("hitPoint").GetComponentInChildren<Transform>();
            var bullet = (GameObject)Instantiate(bulletPrefabs, firePoint.position, firePoint.transform.rotation);
            NetworkServer.Spawn(bullet);

    }
 
}
