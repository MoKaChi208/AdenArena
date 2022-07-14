using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class controllWeapon : MonoBehaviour
{
    //public GameObject bulletPrefabs;
    public Joystick joystick;
    //public GameObject hitPoint;
    //public float BulletForce;
    private Vector3 moveVector;
    //private float nextTimeOfFire = 0;
    public float rotationSpeed = 720;
    //public float fireRate = 1 / 10f; 
    public void Start()
    {
        joystick = GameObject.Find("Fixed Joystick Shoot").GetComponent<Joystick>();
    }

    public void Update()
    {
        if (GetComponentInParent<Player>().isLocalPlayer)
        {

            moveVector = (Vector3.right * joystick.Horizontal + Vector3.up * joystick.Vertical);

            if (moveVector != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, moveVector);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

                //if (Time.time >= nextTimeOfFire)
                //{
                //    //WeaponGun.CmdShot(bulletPrefabs, hitPoint);
                //    nextTimeOfFire = Time.time + fireRate;
                //}
            }
        }
    }

    //[Command]
    //public  void CmdShot(GameObject prefabs, GameObject hitPoint)
    //{
    //    var bullet = (GameObject)Instantiate(prefabs, hitPoint.transform.position, hitPoint.transform.rotation);
    //    NetworkServer.Spawn(bullet);
    //}

    //public Vector3 GetDirectionWeapon()
    //{
    //    return moveVector;
    //}
    //public Vector3 SetVectorForAnimation(Vector3 dir)
    //{
    //    if (dir.x > 0)
    //    {
    //        dir.x = 1;
    //    }
    //    if (dir.x < 0)
    //    {
    //        dir.x = -1;
    //    }
    //    return dir;
    //}
}

