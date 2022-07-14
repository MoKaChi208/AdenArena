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

        if (GetComponent<Player>().isServer) {
            moveVector = (Vector3.right * joystick.Horizontal + Vector3.up * joystick.Vertical);

            if (moveVector != Vector3.zero)
            {

                Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, moveVector);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

                if (Time.time >= nextTimeOfFire)
                {
                    //Player.CmdShot(bulletPrefabs, this.gameObject);
                    CmdShot();
                    nextTimeOfFire = Time.time + fireRate;
                }

            }
        }
        
        


        //Transform parent = GameObject.Find("handGun").GetComponent<Transform>();

        //Debug.Log(parent.rotation);

        //transform.rotation = parent.transform.rotation;
        //transform.localPosition = Vector3.zero;
        //transform.localScale = Vector3.one;
        

    }


    [Command]
    public void CmdShot( /*HitPoint hitPoint*/)
    {

        var bullet = (GameObject)Instantiate(bulletPrefabs, transform.position, transform.rotation);

        NetworkServer.Spawn(bullet);
    }


}
