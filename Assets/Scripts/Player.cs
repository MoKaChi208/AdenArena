using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdTakeDmg(20);
        }
    }
    public void CmdTakeDmg(int dmg)
    {
        currentHealth -= dmg;
        healthBar.SetHealth(currentHealth);
        if (currentHealth < 1)
        {
            RpcOnPlayerDeath();
        }
    }
    void RpcOnPlayerDeath()
    {
        transform.position = Vector3.zero;
        maxHealth = 100;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
}