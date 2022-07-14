using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WeaponGun : NetworkBehaviour
    

{
    public GameObject bulletPrefabs;
    public Joystick joystick;
    [SerializeField]
    private GameObject hitPoint;

    private GameObject firePoint;
    public GameObject Weapon;
    public float BulletForce;
    private Vector3 moveVector;
    private float nextTimeOfFire = 0;
    public float rotationSpeed = 720;
    public float fireRate = 1 / 10f;


    public override void OnStartClient()
    {
        firePoint = Instantiate(hitPoint, hitPoint.transform.position, hitPoint.transform.rotation, GetComponentInChildren<Weapon>().GetComponentInChildren<controllWeapon>().transform);
        joystick = joystick = GameObject.Find("Fixed Joystick Shoot").GetComponent<Joystick>();
        //HitPoint  hitPoint = GameObject.Find("hitPoint").GetComponent<HitPoint>();
    }

    void Update()
    {
        
        moveVector = (Vector3.right * joystick.Horizontal + Vector3.up * joystick.Vertical);
        if (moveVector != Vector3.zero)
        {
            //Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, moveVector);
            ////hitPoint.transform.rotation = Quaternion.RotateTowards(hitPoint.transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            //firePoint.transform.rotation = Quaternion.RotateTowards(Weapon.transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            if (Time.time >= nextTimeOfFire)
            {
                if (isLocalPlayer)
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
    public void CmdShot()
    {
        Debug.Log("Call shoot");
        var bullet = (GameObject)Instantiate(bulletPrefabs, firePoint.transform.position, firePoint.transform.rotation);
        NetworkServer.Spawn(bullet);
    }


}

