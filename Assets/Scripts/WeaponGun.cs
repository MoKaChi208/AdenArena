using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WeaponGun : NetworkBehaviour

{ 
    public GameObject bulletPrefabs;
    public Joystick joystick;
    public HitPoint hitPoint;

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
               
                hitPoint = GameObject.Find("hitPoint").GetComponent<HitPoint>();
                //Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, moveVector);
                //hitPoint.transform.rotation = Quaternion.RotateTowards(hitPoint.transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
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
        var bullet = (GameObject)Instantiate(bulletPrefabs, hitPoint.transform.position, hitPoint.transform.rotation);
        NetworkServer.Spawn(bullet);
    }

 


}
