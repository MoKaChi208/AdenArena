using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefabs;
    public Joystick joystick;

    public float BulletForce;

    void Update()
    {
        Vector3 moveVector = (Vector3.right * joystick.Horizontal + Vector3.up * joystick.Vertical);
        Debug.Log(moveVector);
        if (moveVector != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.zero, moveVector);
            transform.Translate(moveVector * 2 * Time.deltaTime, Space.World);
            CmdShot(moveVector);
        }
        if (joystick.Horizontal == 0 && joystick.Vertical == 0)
        {
            
        }

    }
    public void CmdShot(Vector3 dir)
    {
        GameObject bullet = (GameObject)Instantiate(bulletPrefabs, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(dir * 20, ForceMode2D.Impulse);
        Destroy(bullet, 2);
    }
}
