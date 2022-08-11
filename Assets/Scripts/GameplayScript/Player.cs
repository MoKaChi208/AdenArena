using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour

{
    [SerializeField]
    [SyncVar]
    public string username;
    

    [SerializeField]
    private int maxHealth = 100;

    [SerializeField]
    [SyncVar(hook = "OnChangeHealth")]
    public int currentHealth;

    [SerializeField]
    private HealthBar healthBar;

    [SyncVar]
    public int score;

    [SerializeField]
    private int maxMana = 100;

    

    void OnChangeHealth(int Hp)
    {
        currentHealth = Hp;
    }

    // Start is called before the first frame update

    public void Start()
    {
        
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        username = DBManager.username;
    }
    



    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //CmdTakeDmg(10,transform.name);
                CmdPlusScore(1);
            }
        }


        healthBar.CmdSetHealth(currentHealth);
    }

    //// Use this on server

    //[Command]
    //public void CmdTakeDmg(int dmg, string shoter)
    //{

    //    currentHealth -= dmg;
    //    healthBar.CmdSetHealth(currentHealth);
    //    if (currentHealth < 1)
    //    {
    //        Debug.Log("Shot by" + shoter);
    //        RpcOnPlayerDeath();
    //        GameObject.Find(shoter).GetComponent<Player>().CmdPlusScore(1);
    //    }
    //}



    //use this on client
    //[Command]
    //public void CmdTakeDmg(int dmg)
    //{
    //    currentHealth -= dmg;
    //    healthBar.CmdSetHealth(currentHealth);
    //    if (currentHealth < 1)
    //    {
    //        RpcOnPlayerDeath();
    //    }

    //}
    


    [Command]
    public void CmdTakeDmg()
    {
    }
    
    


    [Command]
    public void CmdPlusScore(int num)
    {
        score += num;
    }
    

    

    [ClientRpc]
    void RpcOnPlayerDeath()
    {
        transform.position = Vector3.zero;
        maxHealth = 100;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    

}
