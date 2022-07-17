using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WeaponGun : NetworkBehaviour
    

{
    public GameObject bulletPrefabs;
    public Joystick joystick;
    [SerializeField]
    private HitPoint hitPoint;
    //private HitPoint firePoint;
    public GameObject Weapon;
    public float BulletForce;
    private Vector3 moveVector;
    private float nextTimeOfFire = 0;
    public float rotationSpeed = 720;
    public float fireRate = 1 / 10f;


    public void Start()
    {
        //firePoint = Instantiate(hitPoint, hitPoint.transform.position, hitPoint.transform.rotation,GetComponent<Player>().transform );
        joystick = joystick = GameObject.Find("Fixed Joystick Shoot").GetComponent<Joystick>();
    }

    void Update()
    {
        
        moveVector = (Vector3.right * joystick.Horizontal + Vector3.up * joystick.Vertical);
        if (moveVector != Vector3.zero)
        {
            //Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, moveVector);
            //firePoint.transform.rotation = Quaternion.RotateTowards(Weapon.transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

            //fire with multiple firePoint, very fun, should keep
            //firePoint.transform.RotateAround(GetComponentInChildren<Weapon>().GetComponentInChildren<controllWeapon>().transform.position, new Vector3(0, 0, 1), rotationSpeed * Time.deltaTime);
            //firePoint.transform.position = hitPoint.transform.position;
            //firePoint.transform.rotation = hitPoint.transform.rotation;


            if (Time.time >= nextTimeOfFire)
            {
                if (isLocalPlayer)
                {
                CmdShot(hitPoint.transform.position, hitPoint.transform.eulerAngles);
                nextTimeOfFire = Time.time + fireRate;
                }
            }
        }
    }
    
    [Command]
    public void CmdShot( Vector3 position, Vector3 rotation)
    {
        var bullet = (GameObject)Instantiate(bulletPrefabs, position, Quaternion.Euler(rotation.x,rotation.y,rotation.z),GetComponent<Player>().transform);
        NetworkServer.Spawn(bullet);
    }


}

