using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class controllWeapon : NetworkBehaviour
{
    public GameObject bulletPrefabs;
    public Joystick joystick;

    public float BulletForce;
    private Vector3 moveVector;

    public float rotationSpeed = 720;
    public void Start()
    {
        joystick = GameObject.Find("Fixed Joystick Shoot").GetComponent<Joystick>();
    }

    public void Update()
    {
        if (!GetComponentInParent<Player>().isLocalPlayer)
        {
            return;
        }
            moveVector = (Vector3.right * joystick.Horizontal + Vector3.up * joystick.Vertical);

            if (moveVector != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, moveVector);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);              
            }
    }
        public Vector3 GetDirectionWeapon()
        {
            return moveVector;
        }
        public Vector3 SetVectorForAnimation(Vector3 dir)
        {
            if (dir.x > 0)
            {
                dir.x = 1;
            }
            if (dir.x < 0)
            {
                dir.x = -1;
            }
            return dir;
        }
}

