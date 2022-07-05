using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchJoystickRotation : MonoBehaviour
{
    public Joystick joystick;
    public GameObject Object;
    Vector2 GameobjectRotation;
    public float returnTime = .8f;
    private float GameobjectRotation2;
    private float GameobjectRotation3;

    public bool FacingRight = true;
    private void Update()
    {
        Aim();
    }
    void Aim()
    {
        //Gets the input from the jostick
        GameobjectRotation = new Vector2(joystick.Horizontal, joystick.Vertical);
        GameobjectRotation.Normalize();

        Vector3 moveVector = (Vector3.up * GameobjectRotation.x + Vector3.left * GameobjectRotation.y);
        if(GameobjectRotation.x !=0 || GameobjectRotation.y != 0)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, moveVector);
        }


        //transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        //if (rotationZ < -90 || rotationZ > 90)
        //{
        //    if (Object.transform.eulerAngles.y == 0)
        //    {
        //        transform.localRotation = Quaternion.Euler(180, 0, -rotationZ);

        //    }
        //    else if (Object.transform.eulerAngles.y == 180)
        //    {
        //        transform.localRotation = Quaternion.Euler(180, 180, -rotationZ);
        //    }
        //}
        if (GameobjectRotation != Vector2.zero)
        {
            Shoot();
            //CmdShot();
        }


    }

    //---------------------Shoot----------
    public Transform firePoint;
    public GameObject bulletPrefabs;

    [HideInInspector]
    public bool canShoot = true;
    private float nextTimeOfFire = 2f;

    public float BulletForce;
    public void CmdShot()
    {
        GameObject bullet = (GameObject)Instantiate(bulletPrefabs, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.up * 20, ForceMode2D.Impulse);
        Destroy(bullet, 2);
    }
    public void Shoot()
    {
        if (GameobjectRotation != Vector2.zero)
        {
            if (Time.time >= nextTimeOfFire)
            {
                CmdShot();
                nextTimeOfFire = Time.time + 1 / 2f;
            }
        }
    }
}
