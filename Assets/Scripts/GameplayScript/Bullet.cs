using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public Player shoter;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Shot by:"+ transform.parent.name);
        //shoter.transform.name = transform.parent.transform.name;
        rb.velocity = transform.up * speed;
        Destroy(gameObject, 2.0f);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                //player.CmdTakeDmg(20, transform.parent.transform.name);
                //player.CmdTakeDmg(20);
                player.CmdTakeDmg();
            }
            Destroy(gameObject);
    }
}

