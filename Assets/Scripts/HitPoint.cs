using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class HitPoint
{

    //public static Transform hitPoint;


    //private void Update()
    //{
    //    hitPoint.transform.rotation = this.transform.rotation;
    //    hitPoint.transform.position = this.transform.position;
    //}
    //public Joystick joystick;
    //private Vector3 moveVector;
    //public float rotationSpeed = 720;
    //public void Start()
    //{
    //    joystick = GameObject.Find("Fixed Joystick Shoot").GetComponent<Joystick>();
    //}

    //public void Update()
    //{
    //    if (!GetComponentInParent<Player>().isLocalPlayer)
    //    {
    //        return;
    //    }
    //    moveVector = (Vector3.right * joystick.Horizontal + Vector3.up * joystick.Vertical);

    //    if (moveVector != Vector3.zero)
    //    {
    //        Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, moveVector);
    //        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
    //    }
    //}

}

