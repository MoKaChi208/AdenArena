using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WeaponGun : NetworkBehaviour
    

{
    public GameObject bulletPrefabs;
    public Joystick joystick;
    [SerializeField]
    private Transform hitPoint;
    public float BulletForce;
    private Vector3 moveVector;
    private float nextTimeOfFire = 0;
    public float rotationSpeed = 720;
    public float fireRate = 1 / 10f;



    void Start()
    {

        joystick = joystick = GameObject.Find("Fixed Joystick Shoot").GetComponent<Joystick>();
        //HitPoint  hitPoint = GameObject.Find("hitPoint").GetComponent<HitPoint>();
    }

    


    void Update()
    {

        if (isLocalPlayer)
        {
            moveVector = (Vector3.right * joystick.Horizontal + Vector3.up * joystick.Vertical);
            if (moveVector != Vector3.zero)
            {
                if (Time.time >= nextTimeOfFire)
                {
                    //hitPoint = GameObject.Find("hitPoint").GetComponentInChildren<GameObject>();  
                    CmdShot();
                    nextTimeOfFire = Time.time + fireRate;
                    Debug.Log("Pang Pang Pang") ;
                }
            }
        }
    }
    
    [Command]
    public /*static*/ void CmdShot( /*HitPoint hitPoint*/)
    {
        var bullet = (GameObject)Instantiate(bulletPrefabs, hitPoint.position, hitPoint.rotation);
        NetworkServer.Spawn(bullet);
    }


}

