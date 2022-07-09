using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefabs;
    public GameObject sprite;
    public Joystick joystick;

    public float BulletForce;
    private Vector3 faceDirection;

    public float rotationSpeed = 720;
    private float nextTimeOfFire = 0;

    void Update()
    {
        rotationSpeed = 720;
        Vector3 moveVector = (Vector3.right * joystick.Horizontal + Vector3.up * joystick.Vertical);
        Debug.Log(moveVector);


        if (moveVector != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, moveVector);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            if (Time.time >= nextTimeOfFire)
            {
                CmdShot(moveVector);
                nextTimeOfFire = Time.time + 1 / 0.9f;
            }
        }
    }
    public void CmdShot(Vector3 dir)
    {
        GameObject bullet = (GameObject)Instantiate(bulletPrefabs, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * 20, ForceMode2D.Impulse);
        Destroy(bullet, 2);
    }
}
