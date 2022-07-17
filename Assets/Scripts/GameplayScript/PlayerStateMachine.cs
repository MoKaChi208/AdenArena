using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerStateMachine : NetworkBehaviour
{
    private Rigidbody2D rigid;
    public float moveSpeed = 8f;
    public Joystick joystick;
    Vector3 moveVector;

    private Vector3 moveDir;
    private Vector3 lastMoveDir;

    [SerializeField]
    private Animator anim;
    [SerializeField]

    void Start()
    {
        lastMoveDir.x = -1;
        rigid = GetComponent<Rigidbody2D>();
        joystick = GameObject.Find("Fixed Joystick Move").GetComponent<Joystick>();
    }
    private void Update()
    {
        if (isLocalPlayer)
        {
            PlayerMove();  
            ControlAnimation();  
        }
        
        
    }

    void PlayerMove()
    {
        moveVector = (Vector3.right * joystick.Horizontal + Vector3.up * joystick.Vertical);
        SetVectorForAnimation();
        if (moveVector != Vector3.zero)
        {
            rigid.velocity = moveVector * moveSpeed;
            lastMoveDir = dirMove();
        }
        if (joystick.Horizontal == 0 && joystick.Vertical == 0)
        {
            moveVector = Vector3.zero;
            rigid.velocity = Vector2.zero;
        }
    }

    public void SetVectorForAnimation()
    {
        if (lastMoveDir.x > 0)
        {
            lastMoveDir.x = 1;
        }
        if (lastMoveDir.x < 0)
        {
            lastMoveDir.x = -1;
        }
    }
    public Vector3 dirMove()
    {
        Vector3 dirAnim = moveVector;
        if (dirAnim.x > 0)
        {
            dirAnim.x = 1;
        }
        if (dirAnim.x < 0)
        {
            dirAnim.x = -1;
        }
        return dirAnim;
    }

    enum State { IDLE, WALKING, GLIDING, JUMPING, LOADING_WRROW, AIMING, DEAD, FLINCH, ATTACK };
    private State state = State.WALKING;

    public void CmdIdle()
    {
        if (state != State.DEAD && state != State.IDLE)
        {
            //anim.SetFloat("MoveMagnitude", moveVector.magnitude);
            anim.SetFloat("LastMoveX", lastMoveDir.x); //Idle
            anim.Play("Stand");
            state = State.IDLE;
        }
    }
    public void CmdWalk()
    {
        if (state != State.DEAD)
        {
            anim.SetFloat("MoveX", dirMove().x);//Walk
            //anim.SetFloat("MoveMagnitude", moveVector.magnitude);
            if (state != State.WALKING)
            {
                anim.SetFloat("MoveX", dirMove().x);//Walk
                //anim.SetFloat("MoveMagnitude", moveVector.magnitude);
                anim.Play("Walk");
                state = State.WALKING;
            }
        }
    }

    public void IdleWithWeapon()
    {

    }

    protected  void ControlAnimation()
    {
        if (false)
        {
            //sprite.Die();
        }
        else if (isRunning())
        {
            CmdWalk();
        }
        else
        {
           CmdIdle();
        }
    }
    public virtual bool isRunning()
    {
        return Mathf.Abs(rigid.velocity.x) >= 0.2f;
    }
}

