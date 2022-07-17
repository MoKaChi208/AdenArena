using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class ControllHitPoint : NetworkBehaviour
{
    

    public GameObject bulletPrefabs;
    public Joystick joystick;
    //[SerializeField]
    //private Transform hitPoint;
    public float BulletForce;
    private Vector3 moveVector;
    private float nextTimeOfFire = 0;

    public float rotationSpeed = 720;
    public float fireRate = 1 / 10f;
    

    public void Start()
    {
        joystick = GameObject.Find("Fixed Joystick Shoot").GetComponent<Joystick>();

    }


    public void Update()
    {

        if (GetComponent<Player>().isServer)
        {
            moveVector = (Vector3.right * joystick.Horizontal + Vector3.up * joystick.Vertical);

            if (moveVector != Vector3.zero)
            {

                Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, moveVector);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
        }
        


    }
}
