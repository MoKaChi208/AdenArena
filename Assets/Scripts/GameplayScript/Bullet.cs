using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public Player owner;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
        Destroy(gameObject, 2.0f);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        { player.CmdTakeDmg(20);
            if (player.currentHealth < 0)
            {
                owner.CmdPlusScore(1); 
            }
        }
        Destroy(gameObject);
    }
}

