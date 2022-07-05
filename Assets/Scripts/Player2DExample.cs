using UnityEngine;

public class Player2DExample : MonoBehaviour
{
    private Rigidbody2D rigid;
    public float moveSpeed = 8f;
    public Joystick joystick;
    Vector3 moveVector;

    private Vector3 moveDir;
    private Vector3 lastMoveDir;

    [SerializeField]
    private Animator anim;
    void Start()
    {
        lastMoveDir.x = -1;
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        moveVector = (Vector3.right * joystick.Horizontal + Vector3.up * joystick.Vertical);
        SetVectorForAnimation();
        if (moveVector != Vector3.zero)
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.forward, moveVector);
            //transform.Translate(moveVector * moveSpeed * Time.deltaTime, Space.World);
            rigid.velocity = moveVector * moveSpeed;
            lastMoveDir = dirMove();
        }
        if (joystick.Horizontal == 0 && joystick.Vertical == 0)
        {
            moveVector = Vector3.zero;
            rigid.velocity = Vector2.zero;

        }
        //Debug.Log(moveVector);
        Animate();
        Debug.Log("lastMove" + lastMoveDir);
    }

    void Animate()
    {
        anim.SetFloat("MoveX", dirMove().x);//Walk

        anim.SetFloat("MoveMagnitude", moveVector.magnitude);


        anim.SetFloat("LastMoveX", lastMoveDir.x); //Idle


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
}
