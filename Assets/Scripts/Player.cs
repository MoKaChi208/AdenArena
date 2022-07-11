using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour

{
    [SerializeField]
    private int maxHealth = 100;
    [SerializeField][SyncVar(hook = "OnChangeHealth")]
    private int currentHealth;
    [SerializeField]
    private HealthBar healthBar;
    
  
  


    [SerializeField]
    private int maxMana = 100;

    void OnChangeHealth(int Hp)
    {
        currentHealth = Hp;
    }

    private void Awake()
    {

    }
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
    

    [Command]
    public void CmdTakeDmg(int dmg)
    {
        currentHealth -= dmg;
        healthBar.CmdSetHealth(currentHealth);
        if (currentHealth < 1)
        {
            RpcOnPlayerDeath();
        }
    }
    

    [ClientRpc]
    void RpcOnPlayerDeath()
    {
        transform.position = Vector3.zero;
        maxHealth = 100;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    

    void OnTriggerEnter2D(Collider2D other)
    {
        CmdTakeDmg(10);
    }
}
